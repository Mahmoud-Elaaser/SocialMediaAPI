using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Repositories
{
    public interface IFollowRepository
    {
        Task FollowUserAsync(int followerId, int followingId);
        Task UnfollowUserAsync(int followerId, int followingId);
        Task<bool> IsFollowingAsync(int followerId, int followingId);
        Task<IEnumerable<Follow>> GetFollowersAsync(int userId);
        Task<IEnumerable<Follow>> GetFollowingAsync(int userId);
    }
}
