using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformAPI.Data;
using SocialMediaPlatformAPI.Interfaces;
using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LikeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MakeLike(Like like)
        {
            await _dbContext.Likes.AddAsync(like);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveLike(Like like)
        {
            _dbContext.Likes.Remove(like);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Like>> GetAllLikes()
        {
            var likes = await _dbContext.Likes.ToListAsync();
            return likes;
        }

        public async Task<Like> MadeLikeOrNot(int followerId)
        {
            var like = await _dbContext.Likes.FindAsync(followerId);
            if (like == null) throw new KeyNotFoundException($"There is no Likes with this id {followerId}");
            return like;
        }
    }
}
