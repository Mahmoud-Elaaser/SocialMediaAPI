using SocialMediaPlatformAPI.DTOs;
using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<UserDto> UpdateUserAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(int id);

        Task<bool> UserExists(string email);
        Task<UserDto> GetUserByEmailAsync(string email);
    }

}
