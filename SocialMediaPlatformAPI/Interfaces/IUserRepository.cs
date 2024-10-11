using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetallUser();
        Task DeleteUser(User user);
        Task UpdateUser(User user);
        Task CreateUser(User user);

        Task<bool> UserExists(string email);
        Task<User> GetUserByEmail(string email);
    }
}
