using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatformAPI.DTOs;
using SocialMediaPlatformAPI.Models;
using SocialMediaPlatformAPI.Services;

namespace SocialMediaPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAllCommentAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDto commentDto)
        {
            var comment = await _commentService.CreateCommentAsync(commentDto);
            return Ok(comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentDto commentDto)
        {
            if (id != commentDto.Id) return BadRequest("Comment ID mismatch.");
            
            var updatedComment = await _commentService.UpdateCommentAsync(id, commentDto);
            if (updatedComment == null) return NotFound();

            return Ok(updatedComment); /// Return the updated comment Dto
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentService.DeleteCommentAsync(id);
            if (!comment) throw new KeyNotFoundException($"Post with id {id} not found");
            return Ok("Comment Deleted Successfully");
        }

    }
}
