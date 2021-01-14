﻿using System.Linq;
using _.Dtos;
using _.Models;
using AutoMapper;
using TempWeb.Models;

namespace _.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>().ForMember(dest =>dest.PhotoUrl, opt 
                => opt.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url));
            CreateMap<User, UserForDetailedDto>().ForMember(dest =>dest.PhotoUrl, opt 
                => opt.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url));;
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}