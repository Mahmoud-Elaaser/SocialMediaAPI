using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformAPI.DTOs;
using SocialMediaPlatformAPI.Services;

namespace SocialMediaPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLikes()
        {
            var likes = await _likeService.GetAllLikesAsytnc();
            return Ok(likes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetlikeById(int id)
        {
            var like = await _likeService.GetLikeByIdAsync(id);
            return Ok(like);
        }

        [HttpPost]
        public async Task<IActionResult> Createlike([FromBody] LikeDto likeDto)
        {
            var like = await _likeService.AddLikeAsync(likeDto);
            return Ok(like);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelike(int id)
        {
            var like = await _likeService.RemoveLikeasync(id);
            if (like == null) throw new KeyNotFoundException($"Like with id {id} not found");
            return Ok("Like Removed Successfully");
        }

    }
}
