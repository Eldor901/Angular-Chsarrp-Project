using _.Dtos;
using AutoMapper;
using TempWeb.Models;

namespace _.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDetailedDto>();
            CreateMap<Role, RolesDto>();
        }
        
    }
}