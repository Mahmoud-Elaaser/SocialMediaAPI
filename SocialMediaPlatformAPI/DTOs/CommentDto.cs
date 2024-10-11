using System.ComponentModel.DataAnnotations;

namespace SocialMediaPlatformAPI.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; } 
    }
}
