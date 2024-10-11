using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformAPI.Data;
using SocialMediaPlatformAPI.Models;


namespace SocialMediaPlatformAPI.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task FollowUserAsync(int followerId, int followingId)
        {
            var follow = new Follow 
            { 
                FollowerId = followerId, 
                FollowingId = followingId 
            };
            await _dbContext.Follows.AddAsync(follow);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UnfollowUserAsync(int followerId, int followingId)
        {
            var follow = await _dbContext.Follows
                            .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);

            if (follow == null) throw new KeyNotFoundException("Follower ID doesn't match Following ID.");

            _dbContext.Follows.Remove(follow);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<bool> IsFollowingAsync(int followerId, int followingId)
        {
            var following =  await _dbContext.Follows.AnyAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);
            if (!following) return false;

            return true;
        }

        public async Task<IEnumerable<Follow>> GetFollowersAsync(int userId)
        {
            var followers = await _dbContext.Follows
                                    .Where(f => f.FollowingId == userId)
                                    .ToListAsync();

            return followers;
        }

        public async Task<IEnumerable<Follow>> GetFollowingAsync(int userId)
        {
            var following =  await _dbContext.Follows
                                    .Where(f => f.FollowerId == userId)
                                    .ToListAsync();

            return following;
        }
    }
}
