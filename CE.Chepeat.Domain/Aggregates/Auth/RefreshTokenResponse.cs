/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 09/10/2024
/// Creation Description : Modelo de petición
/// Update Date : 12/10/2024
/// Update Description : Creación de clase
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Auth;
public class RefreshTokenResponse
{
    public int NumError { get; set; }
    public string Result { get; set; }
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty ;
}
