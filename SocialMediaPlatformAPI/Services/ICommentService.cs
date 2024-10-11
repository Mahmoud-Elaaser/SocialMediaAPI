using SocialMediaPlatformAPI.DTOs;

namespace SocialMediaPlatformAPI.Services
{
    public interface ICommentService
    {
        Task<CommentDto> CreateCommentAsync(CommentDto commentDto);
        Task<CommentDto> UpdateCommentAsync(int id, CommentDto commentDto);
        Task<bool> DeleteCommentAsync(int id);
        Task<IEnumerable<CommentDto>> GetAllCommentAsync();
        Task<CommentDto> GetCommentByIdAsync(int id);
    }
}
