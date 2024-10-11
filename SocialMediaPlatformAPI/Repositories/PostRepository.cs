using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformAPI.Data;
using SocialMediaPlatformAPI.Interfaces;
using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePost(Post post)
        {
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePost(Post post)
        {
            _dbContext.Posts.Update(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePost(Post post)
        {
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            var posts = await _dbContext.Posts
                                            .Include(p => p.Likes)
                                            .Include(p => p.Comments)
                                            .ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostById(int id)
        {
            var post = await _dbContext.Posts.Include(p => p.Likes)
                                             .Include(p => p.Comments)
                                             .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) throw new KeyNotFoundException($"Post with id {id} not found");
            return post;
        }
    }
}
