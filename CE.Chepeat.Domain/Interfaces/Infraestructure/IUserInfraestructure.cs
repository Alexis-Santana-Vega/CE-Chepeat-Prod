using CE.Chepeat.Domain.Aggregates.User;

/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 03/10/2024
/// Creation Description:Interface
/// Update Date : --
/// Update Description : --
/// CopyRight: Chepeat
namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface IUserInfraestructure
{
    /// <summary>
    /// Consulta un registro de la tabla CE_User
    /// </summary>
    /// <returns></returns>
    Task<List<UserDto>> GetUsers();

    /// <summary>
    /// Crear un registro a Users
    /// </summary>
    /// <returns></returns>
    Task<RespuestaDB> AddUser(UserAggregate userAggregate);

    /// <summary>
    /// Crear un registro a Users
    /// </summary>
    /// <returns></returns>
    Task<RespuestaDB> DeleteUser(Guid Id);

    /// <summary>
    /// Crear un registro a Users
    /// </summary>
    /// <returns></returns>

    Task<RespuestaDB> UpdateUser(UserAggregate userAggregate);
}
