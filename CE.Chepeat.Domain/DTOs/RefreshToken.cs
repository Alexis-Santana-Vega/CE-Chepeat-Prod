/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 10/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.DTOs;
public class RefreshToken
{
    [Key]
    public Guid RefreshTokenId { get; set; }
    public string RefreshTokenValue { get; set; }
    public bool Active { get; set; }
    public DateTime Creation {  get; set; }
    public DateTime Expiration { get; set; }
    public bool Used { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}
