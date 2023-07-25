using AutoMapper;
using Domain.Entities;
using Domain.Service.Models.Dtos;

namespace AppServices.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegistrationDto, AppUser>();
        }
    }
}
