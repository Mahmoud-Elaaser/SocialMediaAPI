using AutoMapper;
using SocialMediaPlatformAPI.DTOs;
using SocialMediaPlatformAPI.Interfaces;
using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public LikeService(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<LikeDto> AddLikeAsync(LikeDto likeDto)
        {
            var like = _mapper.Map<Like>(likeDto);
            await _likeRepository.MakeLike(like);
            return _mapper.Map<LikeDto>(like);
        }

        public async Task<LikeDto> RemoveLikeasync(int id)
        {
            var like = await _likeRepository.MadeLikeOrNot(id);
            await _likeRepository.RemoveLike(like);
            return _mapper.Map<LikeDto>(like);
        }

        public async Task<IEnumerable<LikeDto>> GetAllLikesAsytnc()
        {
            var likes = await _likeRepository.GetAllLikes();
            return _mapper.Map<IEnumerable<LikeDto>>(likes);    
        }

        public async Task<LikeDto> GetLikeByIdAsync(int followerId)
        {
            var madeLike = await _likeRepository.MadeLikeOrNot(followerId);
            if (madeLike == null) throw new KeyNotFoundException($"Like with followerId {followerId} wasn't found");
            return _mapper.Map<LikeDto>(madeLike);
        }
    }
}
