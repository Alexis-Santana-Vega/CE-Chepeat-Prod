/// Developer : Hector Nuñez Cruz
/// Creation Date : 20/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.DTOs.Comment
{
    public class Comments
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdSeller { get; set; }
        public Guid IdBuyer { get; set; }
        public Guid IdTransaction { get; set; }
        public string Message { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}