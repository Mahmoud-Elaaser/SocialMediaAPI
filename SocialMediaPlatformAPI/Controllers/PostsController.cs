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
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetallPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostDto postDto)
        {
            var post = await _postService.AddPostAsync(postDto);
            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostDto postDto)
        {
            if (id != postDto.Id) return BadRequest("Post ID mismatch.");
            
            var updatedPost = await _postService.UpdatePostAsync(id, postDto);
            if (updatedPost == null) return NotFound();

            return Ok(updatedPost);           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _postService.DeletePostasync(id);
            if (!post) throw new KeyNotFoundException($"Post with id {id} not found");
            return Ok("Post Deleted Successfully");
        }
    }
}
