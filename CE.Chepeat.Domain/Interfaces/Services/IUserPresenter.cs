using CE.Chepeat.Domain.Aggregates.User;

/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 03/10/2024
/// Creation Description : Interface
/// Update Date : --
/// Update Description : --
/// CopyRight: Chepeat
namespace CE.Chepeat.Domain.Interfaces.Services;
public interface IUserPresenter
{
    /// <summary>
    /// Consulta un registro de la tabla CE_User
    /// </summary>
    /// <returns></returns>
    Task<List<UserDto>> GetUsers();
    Task<RespuestaDB> AddUser(UserAggregate userAggregate);
    Task<RespuestaDB> DeleteUser(Guid id);
    Task<RespuestaDB> UpdateUser(UserAggregate userAggregate);
}
