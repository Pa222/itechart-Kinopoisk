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
            CreateMap<Movie, MovieInfo>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserInfo>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserUpdateProfile, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CreditCard, CreditCardInfo>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Comment, CommentInfo>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Rating, int>().ConvertUsing(r => r.Value);
            CreateMap<UpdateRating, Rating>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}