/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 02/10/2024
/// Creation Description : Modelo de petición
/// Update Date : 10/10/2024
/// Update Description : Implementación de validaciones
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Auth;
public class RegistrationRequest
{
    [Required(ErrorMessage = "Email requerido")]
    [StringLength(50, ErrorMessage = "Email máximo 255 caracteres")]
    [EmailAddress(ErrorMessage = "Email no válido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "NombreCompleto requerido")]
    [StringLength(120, ErrorMessage = "NombreCompleto máximo 120 caracteres")]
    public string Fullname { get; set; }
    [Required(ErrorMessage = "Contraseña requerida")]
    [StringLength(16, ErrorMessage = "Contraseña máximo 16 caracteres")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Confirmar contraseña requerida")]
    [StringLength(16, ErrorMessage = "ConfirmarContraseña máximo 16 caracteres")]
    [Compare("Password", ErrorMessage = "Contraseña y ConfirmarContraseña no coinciden")]
    public string ConfirmPassword { get; set; }
}
