/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 10/11/2024
/// Creation Description : Modelo de petición
/// Update Date : 11/11/2024
/// Update Description : Modificacion general
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.PasswordResetToken;
public class ResetPasswordRequest
{
    public string Token { get; set; }
    public string NewPassword { get; set; }
}
