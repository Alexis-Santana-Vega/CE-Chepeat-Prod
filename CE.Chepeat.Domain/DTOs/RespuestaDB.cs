/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 01/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat
/// 
namespace CE.Chepeat.Domain.DTOs
{
    public class RespuestaDB
    {
        [Key]
        public int NumError {  get; set; }
        public string Result {  get; set; }
        // public List<Lista> Lista { get; set; }
    }

    public class Lista {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
