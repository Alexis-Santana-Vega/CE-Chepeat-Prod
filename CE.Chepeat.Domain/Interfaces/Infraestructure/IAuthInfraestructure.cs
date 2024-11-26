
using CE.Chepeat.Domain.Aggregates.PasswordResetToken;
using CE.Chepeat.Domain.DTOs.PasswordToken;

/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 10/10/2024
/// Creation Description: Interface
/// Update Date : --
/// Update Description : --
/// CopyRight: CE-Chepeat

namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface IAuthInfraestructure
{
    /// <summary>
    ///     Realiza el cambio de contraseña
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> ResetPasswordAsync(ResetPasswordRequest request);
    /// <summary>
    ///     Guarda un token temporal de cambio de contraseña en la base de datos
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> AddPasswordResetToken(PasswordResetToken passwordResetToken); 
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
    ///     Crea el registro para guardar el estado de la sesión, es decir, del refresh token
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> CrearAsync(RefreshToken refreshToken);
    /// <summary>
    ///     Consulta el refresh token en la base de datos
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RefreshToken> ObtenerPorRefreshTokenAsync(RefreshTokenRequest request);
    /// <summary>
    ///     Consulta los tokens del usuario y los inhabilita
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task ListarRefreshToken(RefreshToken refreshToken);
}
