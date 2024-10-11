using AutoMapper;
using SocialMediaPlatformAPI.DTOs;
using SocialMediaPlatformAPI.Interfaces;
using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetPostById(id);
            if (post == null) throw new KeyNotFoundException($"Post with id {id} wasn't found");
            return post;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPosts();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<PostDto> AddPostAsync(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.CreatePost(post);
            return _mapper.Map<PostDto>(post);
        }


        public async Task<PostDto> UpdatePostAsync(int id, PostDto postDto)
        {
            var post = await _postRepository.GetPostById(id);
            if (post == null) throw new KeyNotFoundException($"Post with id {id} not found.");

            _mapper.Map(postDto, post);

            // Update likes and comments 
            post.Likes = postDto.Likes.Select(like => new Like
            {
                UserId = like.UserId,
                PostId = post.Id
            }).ToList();

            post.Comments = postDto.Comments.Select(comment => new Comment
            {
                UserId = comment.UserId,
                PostId = post.Id,
                Content = comment.Content,
                DateCreated = comment.DateCreated
            }).ToList();


            await _postRepository.UpdatePost(post);
            
            return _mapper.Map<PostDto>(post); /// Return the updated PostDto
        }

        public async Task<bool> DeletePostasync(int id)
        {
            var post = await _postRepository.GetPostById(id);
            if (post == null)return false;
            

            await _postRepository.DeletePost(post);
            return true;
        }

    }
}
