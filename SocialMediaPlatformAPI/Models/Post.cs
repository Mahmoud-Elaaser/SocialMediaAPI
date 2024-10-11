using System.ComponentModel.DataAnnotations;

namespace SocialMediaPlatformAPI.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; } 

        [Required, MaxLength(2000)]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        public User User { get; set; }

        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
