/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 01/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.DTOs.Session;
public class Session
{
    public Guid Id { get; set; }
    public Guid IdUser { get; set; }
    public string RefreshToken { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}
