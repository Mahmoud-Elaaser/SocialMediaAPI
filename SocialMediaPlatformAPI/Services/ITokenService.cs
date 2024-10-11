using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
