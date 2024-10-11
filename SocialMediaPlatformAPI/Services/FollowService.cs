using SocialMediaPlatformAPI.Models;
using SocialMediaPlatformAPI.Repositories;


namespace SocialMediaPlatformAPI.Services
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;

        public FollowService(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }

        public async Task FollowUserAsync(int followerId, int followingId)
        {
            await _followRepository.FollowUserAsync(followerId, followingId);
        }

        public async Task UnfollowUserAsync(int followerId, int followingId)
        {
            await _followRepository.UnfollowUserAsync(followerId, followingId);
        }

        public async Task<bool> IsFollowingAsync(int followerId, int followingId)
        {
            return await _followRepository.IsFollowingAsync(followerId, followingId);
        }

        public async Task<IEnumerable<Follow>> GetFollowersAsync(int userId)
        {
            return await _followRepository.GetFollowersAsync(userId);
        }

        public async Task<IEnumerable<Follow>> GetFollowingAsync(int userId)
        {
            return await _followRepository.GetFollowingAsync(userId);
        }
    }
}
