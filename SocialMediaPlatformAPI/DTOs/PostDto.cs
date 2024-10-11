using SocialMediaPlatformAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaPlatformAPI.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required, MaxLength(2000)]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        public List<LikeDto> Likes { get; set; } = new List<LikeDto>();
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
