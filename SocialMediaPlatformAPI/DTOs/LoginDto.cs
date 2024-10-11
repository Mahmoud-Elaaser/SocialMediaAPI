using System.ComponentModel.DataAnnotations;

namespace SocialMediaPlatformAPI.DTOs
{
    public class LoginDto
    {
        [Required, EmailAddress, MaxLength(40)]
        public string Email { get; set; }

        [Required, MaxLength(32), MinLength(8)]
        public string Password { get; set; }
    }
}
