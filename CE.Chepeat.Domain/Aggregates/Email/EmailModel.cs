/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 01/11/2024
/// Creation Description : Modelo de petición
/// Update Date : 02/11/2024
/// Update Description : Implementacion de ModelData
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Email;
public class EmailModel
{
    public string To { get; set; }
    public string Subject { get; set; }
    public object ModelData { get; set; } // Datos para la plantilla
}
