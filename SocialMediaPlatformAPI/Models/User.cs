using System.ComponentModel.DataAnnotations;

namespace SocialMediaPlatformAPI.Models
{
    public class User
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

        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
