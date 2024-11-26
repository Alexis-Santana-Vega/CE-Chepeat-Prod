/// Developer : Hector Nuñez Cruz
/// Creation Date : 01/11/2024
/// Creation Description:Interface
/// Update Date : --
/// Update Description : --
/// CopyRight: CE-Chepeat

using CE.Chepeat.Domain.Aggregates.Comments;
using CE.Chepeat.Domain.DTOs.Comment;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure
{
    public interface ICommentInfraestructure
    {
        Task<RespuestaDB> AddComment(CommentAggregate commentAggregate);
        Task<RespuestaDB> UpdateCommentMessage(UpdateCommentMessageAggregate updateMessage);
        Task<RespuestaDB> UpdateCommentRating(UpdateCommentRatingAggregate updateRating);
        Task<Comments> GetCommentById(Guid id);
        Task<List<PublicComment>> GetCommentsBySeller(Guid id);
    }
}