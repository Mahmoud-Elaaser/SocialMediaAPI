using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Interfaces
{
    public interface IPostRepository
    {
        Task CreatePost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(Post post);
        Task<IEnumerable<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
    }
}
