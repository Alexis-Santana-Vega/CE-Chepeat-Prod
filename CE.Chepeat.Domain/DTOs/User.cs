/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 01/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat


using System.Text.Json.Serialization;

namespace CE.Chepeat.Domain.DTOs;
public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public string Fullname { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsBuyer { get; set; }
    public bool IsSeller { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
