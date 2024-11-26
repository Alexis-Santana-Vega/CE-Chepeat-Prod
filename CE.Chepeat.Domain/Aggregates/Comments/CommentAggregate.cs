/// Developer : Hector Nuñez Cruz
/// Creation Date : 01/11/2024
/// Creation Description : Modelo de petición
/// Update Date : 03/10/2024
/// Update Description : Cambios menores
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Comments
{
    public class CommentAggregate
    {
        public Guid IdTransaction { get; set; }
        public string Message { get; set; }
        public decimal Rating { get; set; }
    }

    public class UpdateCommentMessageAggregate
    {
        public Guid Id { get; set; }
        public string NewMessage { get; set; }
        public decimal NewRating { get; set; }
    }

    public class UpdateCommentRatingAggregate
    {
        public Guid CommentId { get; set; }
        public Guid IdUser { get; set; }
        public decimal NewRating { get; set; }
    }
}