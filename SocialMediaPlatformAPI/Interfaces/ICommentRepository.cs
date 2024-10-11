using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Interfaces
{
    public interface ICommentRepository
    {
        Task CreateComment(Comment comment);
        Task UpdateComment(Comment comment);
        Task DeleteComment(Comment comment);
        Task<IEnumerable<Comment>> GetAllComments();
        Task<Comment> GetCommentById(int id);
    }
}
