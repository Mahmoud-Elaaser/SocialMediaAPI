using SocialMediaPlatformAPI.DTOs;

namespace SocialMediaPlatformAPI.Services
{
    public interface ILikeService
    {
        Task<LikeDto> AddLikeAsync(LikeDto likeDto);
        Task<LikeDto> RemoveLikeasync(int id);
        Task<IEnumerable<LikeDto>> GetAllLikesAsytnc();
        Task<LikeDto> GetLikeByIdAsync(int followerId);
    }
}
