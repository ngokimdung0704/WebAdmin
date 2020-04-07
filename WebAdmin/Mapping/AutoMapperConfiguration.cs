using System;
using AutoMapper;
using Domain.Models;
using WebAdmin.Models;

namespace WebApp.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<User, UserRawViewModel>()
                    .ForMember(x => x.CreatedDate, options => options.MapFrom(x => DateTime.Now))
                    .ForMember(x => x.LastUpdatedDate, options => options.MapFrom(x => DateTime.Now));

            CreateMap<UserDetailViewModel, User>()
                    .ForMember(x => x.LastUpdatedDate, options => options.MapFrom(x => DateTime.Now));

            CreateMap<UserUpdatePasswordViewModel, User>()
                    .ForMember(x => x.LastUpdatedDate, options => options.MapFrom(x => DateTime.Now));
                    
            CreateMap<User, UserDetailViewModel>();
            CreateMap<User, UserUpdatePasswordViewModel>();
            CreateMap<UserCreateViewModel, User>();
        }
    }
}