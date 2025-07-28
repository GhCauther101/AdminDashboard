using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Models;
using AutoMapper;

namespace AdminDashboard.API.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>()
            .ForMember(d => d.CientId, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
            .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email));
    }
}