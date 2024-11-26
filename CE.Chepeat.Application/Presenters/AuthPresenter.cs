using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using CE.Chepeat.Application.Services;
using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.Aggregates.Email;
using CE.Chepeat.Domain.Aggregates.PasswordResetToken;
using CE.Chepeat.Domain.Aggregates.User;
using CE.Chepeat.Domain.DTOs.PasswordToken;
using CE.Chepeat.Domain.DTOs.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CE.Chepeat.Application.Presenters;
public class AuthPresenter : IAuthPresenter
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;

    public AuthPresenter(IUnitRepository unitRepository, IMapper mapper, IJwtService jwtService)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<RefreshToken> ObtenerPorRefreshTokenAsync(RefreshTokenRequest request)
    {
        return await _unitRepository.authInfraestructure.ObtenerPorRefreshTokenAsync(request);

    }

    public Task<RespuestaDB> EliminarAsync(Session session)
    {
        throw new NotImplementedException();
    }

    public async Task<RefreshTokenResponse> RefrescarToken(RefreshTokenRequest request)
    {
        var refreshToken = await _unitRepository.authInfraestructure.ObtenerPorRefreshTokenAsync(request);
        // Si el refresh token no existe, expiro o lo eliminaron manualmente, igual pensando que el usuario
        // tuviera la opcion de cerrar sesion en todos lados
        if (refreshToken == null || refreshToken.Active == false || refreshToken.Expiration <= DateTime.UtcNow)
        {
            return new RefreshTokenResponse { NumError = 3, Result = "Refresh token no existe, expiro o fue eliminado" };
        }
        // Si se esta intentado utilizar el refresh token que ya fue utilizado anteriormente
        // posiblemente fue robado o la aplicacion cliente no se esta implementando correctamente
        // Por ello, por seguridad se desactivaran todos los refresh token de ese usuario por seguridad
        Console.WriteLine(refreshToken.RefreshTokenValue);
        if (refreshToken.Used)
        {
            await _unitRepository.authInfraestructure.ListarRefreshToken(refreshToken);
            return new RefreshTokenResponse { NumError = 4, Result = "Error 403 Forbidden Access Exception - Se desactivaron todos los tokens por seguridad" };
        }
        // Validar que el Access Token corresponde al mismo usuario
        refreshToken.Used = true;
        refreshToken.Active = false;
        var user = await _unitRepository.authInfraestructure.ObtenerPorId(refreshToken.UserId);
        if (user == null) {
            return new RefreshTokenResponse { NumError = 5, Result = "Error 403 Forbidden Access Exception" };
        }
        var jwt = _jwtService.GenerarToken(user);
        var newToken = _jwtService.GenerarRefreshToken();

        var newRefreshToken = new RefreshToken
        {
            Active = true,
            Creation = DateTime.UtcNow,
            Expiration = DateTime.UtcNow.AddDays(30),
            RefreshTokenValue = newToken,
            Used = false,
            UserId = user.Id
        };

        var response = await CrearAsync(newRefreshToken);
        Console.WriteLine(response.Result);

        await _unitRepository.Complete();

        return new RefreshTokenResponse
        {
            NumError = 0,
            Result = "Has refrescado tu sesion con exito",
            Token = jwt,
            RefreshToken = newToken
        };

        /*
        if (string.IsNullOrEmpty(request.RefreshToken))
        {
            return new RefreshTokenResponse { NumError = 3, Result = "Refresh token vacio, no existe" };
        }

        var user = await _unitRepository.authInfraestructure.ObtenerPorId(id);
        var token = _jwtService.GenerarToken(user);
        */

        /*
        var session = await _unitRepository.authInfraestructure.ObtenerPorRefreshTokenAsync(request.RefreshToken);
        if (session == null || session.ExpiresAt <= DateTime.UtcNow)
        {
            return new LoginResponse { NumError = 2, Result = "Refresh token invalido o expirado" };
        }
        var user = await _unitRepository.authInfraestructure.ObtenerPorId(session.IdUser);
        var token = _jwtService.GenerarToken(user);
        var nuevoRefreshToken = _jwtService.GenerarRefreshToken();

        session.RefreshToken = nuevoRefreshToken;
        session.CreatedAt = DateTime.UtcNow;
        session.ExpiresAt = DateTime.UtcNow.AddDays(20);

        await _unitRepository.authInfraestructure.CrearAsync(session);
        */


        // return new RefreshTokenResponse { NumError = 1, Result = "Refresh Token Generado con Exito", Token = token };
    }

    public Task<RespuestaDB> CrearAsync(RefreshToken refreshToken)
    {
        return _unitRepository.authInfraestructure.CrearAsync(refreshToken);
    }

    /// <summary>
    ///     Realiza el inicio de sesion del usuario y genera el JWT
    /// </summary>
    /// <returns>
    ///     new LoginResponse { NumError: 0, Result: "Mensaje", Token: "JWTTOKEN", RefreshToken: "REFRESHTOKEN" }
    /// </returns>
    public async Task<LoginResponse> IniciarSesion(LoginRequest request)
    {
        var user = await ObtenerPorEmail(request.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return new LoginResponse {
                NumError = 1,
                Result = "Credenciales no válidas"
            };
        }
        var jwt = _jwtService.GenerarToken(user);
        var refreshToken = _jwtService.GenerarRefreshToken();

        var newAccessToken = new RefreshToken
        {
            Active = true,
            Creation = DateTime.UtcNow,
            Expiration = DateTime.UtcNow.AddDays(60),
            RefreshTokenValue = refreshToken,
            Used = false,
            UserId = user.Id
        };

        var response = await CrearAsync(newAccessToken);
        Console.WriteLine(response.Result);
        
        return new LoginResponse {
            NumError = 0,
            Result = "Has iniciado sesion con exito",
            Token = jwt,
            RefreshToken = refreshToken,
            User = user
        };
    }

    /// <summary>
    ///     Consulta el usuario a traves de su Email
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    public Task<User> ObtenerPorEmail(string email)
    {
        return _unitRepository.authInfraestructure.ObtenerPorEmail(email);
    }

    /// <summary>
    ///     Consulta el usuario a traves de su ID
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    public Task<User> ObtenerPorId(Guid id)
    {
        return _unitRepository.authInfraestructure.ObtenerPorId(id);
    }

    /// <summary>
    ///     Realiza la insersión de un nuevo usuario a la tabla Users
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    public async Task<RespuestaDB> RegistrarUsuario(RegistrationRequest request)
    {
        request.Password =  BCrypt.Net.BCrypt.HashPassword(request.Password);
        var response = await _unitRepository.authInfraestructure.RegistrarUsuario(request);

        var emailModel = new EmailModel
        {
            To = request.Email,
            Subject = "Bienvenido a Chepeat",
            ModelData = new { Fullname = request.Fullname }
        };

        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "TemplateBienvenida.cshtml");

        if (!File.Exists(templatePath))
        {
            Console.Write("No fue posible encontrar la ruta del archivo de la plantilla");
            response.Result += " No fue posible enviar el correo porque no se encontro la plantilla";
            return response;
        }
        await _unitRepository.emailServiceInfraestructure.SendEmailAsync(emailModel, templatePath);
        return response;
    }

    public async Task<RespuestaDB> CerrarSesion(RefreshTokenRequest request)
    {
        return await _unitRepository.authInfraestructure.CerrarSesion(request);
    }

    public async Task<RespuestaDB> CerrarSesionTodos(Guid id)
    {
        return await _unitRepository.authInfraestructure.CerrarSesionTodos(id);
    }

    public async Task<RespuestaDB> RequestPasswordResetAsync(string email)
    {
        var user = await _unitRepository.authInfraestructure.ObtenerPorEmail(email);
        if (user == null) return new RespuestaDB { NumError = 1, Result = "Usuario no encontrado" };
        var token = new PasswordResetToken
        {
            UserId = user.Id,
            Token = Guid.NewGuid().ToString(),
            ExpirationDate = DateTime.UtcNow.AddMinutes(30),
            IsUsed = false
        };
        var response = await _unitRepository.authInfraestructure.AddPasswordResetToken(token);
        var emailModel = new EmailModel
        {
            To = email,
            Subject = "Recuperación de contraseña",
            ModelData = new { Link = $"https://localhost:3000/newContra?token={token.Token}" }
        };
        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "TemplatePassword.cshtml");
        if (!File.Exists(templatePath))
        {
            Console.Write("No fue posible encontrar la ruta del archivo de la plantilla");
            return new RespuestaDB { NumError = 2, Result = "No se encontro la plantilla pero se guardo el token" };
        }
        await _unitRepository.emailServiceInfraestructure.SendEmailAsync(emailModel, templatePath);
        response.Result = "Correo enviado con exito";
        return response;
    }

    public async Task<RespuestaDB> ResetPasswordAsync(ResetPasswordRequest request)
    {
        request.NewPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        return await _unitRepository.authInfraestructure.ResetPasswordAsync(request);
    }

    public async Task<RespuestaDB> RequestPasswordResetReactNativeAsync(string email)
    {
        var user = await _unitRepository.authInfraestructure.ObtenerPorEmail(email);
        if (user == null) return new RespuestaDB { NumError = 1, Result = "Usuario no encontrado" };
        var token = new PasswordResetToken
        {
            UserId = user.Id,
            Token = Guid.NewGuid().ToString(),
            ExpirationDate = DateTime.UtcNow.AddMinutes(30),
            IsUsed = false
        };
        var response = await _unitRepository.authInfraestructure.AddPasswordResetToken(token);
        var emailModel = new EmailModel
        {
            To = email,
            Subject = "Recuperación de contraseña",
            ModelData = new { Link = $"{token.Token}" }
        };
        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "TemplatePasswordReactNative.cshtml");
        if (!File.Exists(templatePath))
        {
            Console.Write("No fue posible encontrar la ruta del archivo de la plantilla");
            return new RespuestaDB { NumError = 2, Result = "No se encontro la plantilla pero se guardo el token" };
        }
        await _unitRepository.emailServiceInfraestructure.SendEmailAsync(emailModel, templatePath);
        response.Result = "Correo enviado con exito";
        return response;
    }
}

