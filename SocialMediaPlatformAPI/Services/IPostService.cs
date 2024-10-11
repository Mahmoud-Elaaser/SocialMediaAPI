using SocialMediaPlatformAPI.DTOs;
using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Services
{
    public interface IPostService
    {
        Task<Post> GetPostByIdAsync(int id);
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task<PostDto> AddPostAsync(PostDto postDto);
        Task<PostDto> UpdatePostAsync(int id, PostDto postDto);
        Task<bool> DeletePostasync(int id);

    }
}
