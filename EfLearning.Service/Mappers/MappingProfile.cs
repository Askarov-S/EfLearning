using AutoMapper;
using EfLearning.Domain.Entities;
using EfLearning.Service.DTOs.UserDto;

namespace EfLearning.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //UserMapping
        CreateMap<User, UserForViewModel>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
    }
}
