using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformAPI.Data;
using SocialMediaPlatformAPI.Interfaces;
using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateComment(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteComment(Comment comment)
        {
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            var comments = await _dbContext.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            if (comment == null) throw new KeyNotFoundException($"Comment with id {id} not found.");
            return comment;
        }
    }
}
