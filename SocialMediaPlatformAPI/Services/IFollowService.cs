using SocialMediaPlatformAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaPlatformAPI.Services
{
    public interface IFollowService
    {
        Task FollowUserAsync(int followerId, int followingId);
        Task UnfollowUserAsync(int followerId, int followingId);
        Task<bool> IsFollowingAsync(int followerId, int followingId);
        Task<IEnumerable<Follow>> GetFollowersAsync(int userId);
        Task<IEnumerable<Follow>> GetFollowingAsync(int userId);
    }
}
