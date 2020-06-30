using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Binder.Application.Entities;

using Binder.Shared.User;

namespace Binder
{
    public class MapperAutoProfile : Profile
    {
        public MapperAutoProfile()
        {
            CreateMap<User, UserReadModel>();
            CreateMap<UserCreateModel, User>();
            
            // CreateMap<User,UserReadModel>().ForMember(x=>x.Email,y=>y.MapFrom())
        }
    }
}
