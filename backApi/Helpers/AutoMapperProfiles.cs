using _.Dtos;
using _.Dtos.AddActions;
using _.Models;
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
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<Product, ProductsForDetailDto>();
        }
        
    }
}