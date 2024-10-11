using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformAPI.DTOs;
using SocialMediaPlatformAPI.Interfaces;
using SocialMediaPlatformAPI.Models;
using SocialMediaPlatformAPI.Repositories;

namespace SocialMediaPlatformAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetallUser();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null) throw new KeyNotFoundException($"User with id {id} not found.");
            
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.CreateUser(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(UserDto userDto)
        {
            var user = await _userRepository.GetUserById(userDto.Id);
            if (user == null) throw new KeyNotFoundException($"User with id {userDto.Id} not found.");

            _mapper.Map(userDto, user);

            await _userRepository.UpdateUser(user);

            var updatedUser = await _userRepository.GetUserById(userDto.Id);

            return _mapper.Map<UserDto>(updatedUser); /// Return the updated UserDto
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)return false;
            
            await _userRepository.DeleteUser(user);
            return true;
        }


        public async Task<bool> UserExists(string email)
        {
            return await _userRepository.UserExists(email);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            return _mapper.Map<UserDto>(user);
        }
    }

}
