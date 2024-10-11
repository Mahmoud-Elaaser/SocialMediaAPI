using System.ComponentModel.DataAnnotations;

namespace SocialMediaPlatformAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }

        [Required, MaxLength(200)]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
    }
}
