using System.ComponentModel.DataAnnotations;

namespace SocialMediaPlatformAPI.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required, MaxLength(16)]
        public string Username { get; set; }

        [Required, MaxLength(40)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(32), MinLength(8)]
        public string Password { get; set; }

        [Required, MaxLength(128)]
        public string Bio { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime DateJoined { get; set; }
    }
}
