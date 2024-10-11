using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformAPI.Models;
using SocialMediaPlatformAPI.Services;
using SocialMediaPlatformAPI.DTOs;
using AutoMapper;

namespace SocialMediaPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, IMapper mapper, ITokenService tokenService)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (await _userService.UserExists(registerDto.Email))
            {
                return BadRequest("User already exists with this email.");
            }

            var user = _mapper.Map<UserDto>(registerDto);

            user.DateJoined = DateTime.Now;

            await _userService.CreateUserAsync(user);

            return Ok(new { Message = "Registration successful!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userService.GetUserByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized("Invalid email or password.");

            if (user.Password != loginDto.Password) return Unauthorized("Invalid email or password.");
            
            var userDto = _mapper.Map<UserDto>(user);

            var mappedUser = _mapper.Map<User>(userDto);

            var token = _tokenService.GenerateToken(mappedUser);

            return Ok(new { Token = token });
        }

    }


}
