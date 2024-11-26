/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 09/10/2024
/// Creation Description : Modelo de petición
/// Update Date : 11/10/2024
/// Update Description : Generacion de clases
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Auth;
public class LoginResponse
{
    public int NumError { get; set; }
    public string Result { get; set; }
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DTOs.User? User { get; set; } = null;
}
