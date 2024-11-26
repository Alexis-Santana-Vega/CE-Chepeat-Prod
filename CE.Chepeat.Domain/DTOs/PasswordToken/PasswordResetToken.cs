/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 01/11/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat

using RTools_NTS.Util;

namespace CE.Chepeat.Domain.DTOs.PasswordToken;
public class PasswordResetToken
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsUsed { get; set; }
}
