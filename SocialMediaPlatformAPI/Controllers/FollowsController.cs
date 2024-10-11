using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformAPI.Services;


namespace SocialMediaPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowsController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowsController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpGet("{userId}/followers")]
        public async Task<IActionResult> GetFollowers(int userId)
        {
            var followers = await _followService.GetFollowersAsync(userId);
            return Ok(followers);
        }

        [HttpGet("{userId}/following")]
        public async Task<IActionResult> GetFollowing(int userId)
        {
            var following = await _followService.GetFollowingAsync(userId);
            return Ok(following);
        }

        [HttpGet("isFollowing/{followerId}/{followingId}")]
        public async Task<IActionResult> IsFollowing(int followerId, int followingId)
        {
            var isFollowing = await _followService.IsFollowingAsync(followerId, followingId);
            return Ok(isFollowing);
        }

        [HttpPost("{followerId}/{followingId}")]
        public async Task<IActionResult> FollowUser(int followerId, int followingId)
        {
            await _followService.FollowUserAsync(followerId, followingId);
            return Ok();
        }

        [HttpDelete("{followerId}/{followingId}")]
        public async Task<IActionResult> UnfollowUser(int followerId, int followingId)
        {
            await _followService.UnfollowUserAsync(followerId, followingId);
            return Ok();
        }


        
    }
}
