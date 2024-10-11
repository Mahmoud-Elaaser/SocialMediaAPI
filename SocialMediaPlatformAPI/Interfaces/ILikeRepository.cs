using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Interfaces
{
    public interface ILikeRepository
    {
        Task MakeLike(Like like);
        Task RemoveLike(Like like);
        Task<IEnumerable<Like>> GetAllLikes();
        Task<Like> MadeLikeOrNot(int followerId);
    }
}
