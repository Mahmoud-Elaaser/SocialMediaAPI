using AutoMapper;
using SocialMediaPlatformAPI.DTOs;
using SocialMediaPlatformAPI.Models;

namespace SocialMediaPlatformAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<CommentDto, Comment>().ReverseMap();

            CreateMap<LikeDto, Like>().ReverseMap();

            CreateMap<FollowDto, Follow>().ReverseMap();

            CreateMap<PostDto, Post>().ReverseMap();

            CreateMap<RegisterDto, User>().ReverseMap(); 

            CreateMap<RegisterDto, UserDto>().ReverseMap(); 

            CreateMap<LoginDto, UserDto>().ReverseMap(); 

        }
    }
}
