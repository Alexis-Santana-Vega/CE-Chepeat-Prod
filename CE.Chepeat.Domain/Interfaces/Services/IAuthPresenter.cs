
using CE.Chepeat.Domain.Aggregates.PasswordResetToken;

/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 10/10/2024
/// Creation Description:Interface
/// Update Date : --
/// Update Description : --
/// CopyRight: CE-Chepeat

namespace CE.Chepeat.Domain.Interfaces.Services;
public interface IAuthPresenter
{
    Task<RespuestaDB> RequestPasswordResetReactNativeAsync(string email);
    /// <summary>
    ///     Realiza el cambio de contraseña
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> ResetPasswordAsync(ResetPasswordRequest request);
    /// <summary>
    ///     Envia una solicitud de cambio de contraseña junto con un correo
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> RequestPasswordResetAsync(string email);
    /// <summary>
    ///     Inhabilita los refresh tokens existentes del usuario para cerrar sesión
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> CerrarSesionTodos(Guid id);
    /// <summary>
    ///     Inhabilita el refresh token de la sesión actual
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> CerrarSesion(RefreshTokenRequest request);
    /// <summary>
    ///     Realiza la insersión de un nuevo usuario a la tabla Users
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> RegistrarUsuario(RegistrationRequest request);

    /// <summary>
    ///     Consulta el usuario a traves de su Email
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    Task<User> ObtenerPorEmail(string email);

    /// <summary>
    ///     Consulta el usuario a traves de su ID
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    Task<User> ObtenerPorId(Guid id);

    /// <summary>
    ///     Realiza el inicio de sesion del usuario y genera el JWT
    /// </summary>
    /// <returns>
    ///     new LoginResponse { NumError: 0, Result: "Mensaje", Token: "JWTTOKEN", RefreshToken: "REFRESHTOKEN" }
    /// </returns>
    Task<LoginResponse> IniciarSesion(LoginRequest request);
    /// <summary>
    ///     Crea el registro para guardar el estado de la sesión, es decir, del refresh token
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> CrearAsync(RefreshToken refreshToken);
    /// <summary>
    ///     Crea el registro para guardar el estado de la sesión, es decir, del refresh token
    /// </summary>
    /// <returns>
    ///     new RefreshTokenResponse { NumError: 0, Result: "Mensaje de la BD", Token: "", RefreshToken: "" }
    /// </returns>
    Task<RefreshTokenResponse> RefrescarToken(RefreshTokenRequest request);
    /// <summary>
    ///     Consulta el refresh token en la base de datos
    /// </summary>
    /// <returns>
    ///     new RefreshToken {};
    /// </returns>
    Task<RefreshToken> ObtenerPorRefreshTokenAsync(RefreshTokenRequest request);
}
