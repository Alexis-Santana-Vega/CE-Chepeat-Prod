/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 09/10/2024
/// Creation Description : Modelo de petición
/// Update Date : 11/10/2024
/// Update Description : Implementación de validaciones
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Auth;
public class LoginRequest
{
    [Required(ErrorMessage = "Email requerido")]
    [StringLength(255, ErrorMessage = "Email máximo 255 caracteres")]
    [EmailAddress(ErrorMessage = "Email no válido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Contraseña requerida")]
    [StringLength(16, ErrorMessage = "Contraseña máximo 16 caracteres")]
    public string Password { get; set; }
}
