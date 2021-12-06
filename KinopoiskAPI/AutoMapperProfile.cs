using AutoMapper;
using Data_Access_Layer.Entity;
using KinopoiskAPI.Dto.Comment;
using KinopoiskAPI.Dto.CreditCard;
using KinopoiskAPI.Dto.Movie;
using KinopoiskAPI.Dto.Rating;
using KinopoiskAPI.Dto.User;

namespace KinopoiskAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieInfoDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserInfoDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserUpdateProfileDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CreditCard, CreditCardInfoDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Comment, CommentInfoDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Rating, int>().ConvertUsing(r => r.Value);
            CreateMap<UpdateRatingDto, Rating>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}