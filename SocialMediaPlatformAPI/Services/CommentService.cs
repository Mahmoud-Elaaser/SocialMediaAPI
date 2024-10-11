using AutoMapper;
using SocialMediaPlatformAPI.DTOs;
using SocialMediaPlatformAPI.Interfaces;
using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateCommentAsync(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.CreateComment(comment);
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<CommentDto> UpdateCommentAsync(int id, CommentDto commentDto)
        {
            var comment = await _commentRepository.GetCommentById(id);

            if (comment == null) throw new KeyNotFoundException($"Comment with id {id} wasn't found.");

            _mapper.Map(commentDto, comment);

            await _commentRepository.UpdateComment(comment);
           
            return _mapper.Map<CommentDto>(comment); /// Return the updated Dto
        }


        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = await _commentRepository.GetCommentById(id);
            if (comment == null) throw new KeyNotFoundException($"Comment with id {id} wasn't found");
            await _commentRepository.DeleteComment(comment);
            return true;
        }

        public async Task<IEnumerable<CommentDto>> GetAllCommentAsync()
        {
            var comments = await _commentRepository.GetAllComments();
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetCommentByIdAsync(int id)
        {
            var comment = await _commentRepository.GetCommentById(id);
            if (comment == null) throw new KeyNotFoundException($"Comment with id {id} wasn't found");
            return _mapper.Map<CommentDto>(comment);
        }
    }
}
