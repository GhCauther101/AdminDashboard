using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using AutoMapper;

namespace AdminDashboard.API.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>()
            .ForMember(d => d.ClientId, opt => opt.MapFrom(src => src.Id))
            .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email));

        CreateMap<ClientForUpdate, Client>()
            .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClientId))
            .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(d => d.Password, opt => opt.MapFrom(src => src.Password));

        CreateMap<Payment, PaymentDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(src => src.PaymentId))
            .ForMember(d => d.SourceClientId, opt => opt.MapFrom(src => src.SourceClient.Id))
            .ForMember(d => d.DestinationClientId, opt => opt.MapFrom(src => src.DestinationClient.Id))
            .ForMember(d => d.Bill, opt => opt.MapFrom(src => src.Bill))
            .ForMember(d => d.ProcessTime, opt => opt.MapFrom(src => src.ProcessTime));

        CreateMap<PaymentDto, Payment>()
            .ForMember(d => d.PaymentId, opt => opt.MapFrom(src => src.Id))
            .ForMember(d => d.SourceClientId, opt => opt.MapFrom(src => src.SourceClientId))
            .ForMember(d => d.DestinationClientId, opt => opt.MapFrom(src => src.DestinationClientId))
            .ForMember(d => d.Bill, opt => opt.MapFrom(src => src.Bill))
            .ForMember(d => d.Bill, opt => opt.MapFrom(src => src.ProcessTime));

        CreateMap<ClientQueryResult, ClientWebReply<ClientDto>>()
            .ForMember(d => d.IsSuccess, opt => opt.MapFrom(src => src.IsSuccess))
            .ForMember(d => d.Data, opt => opt.MapFrom(src => src.Entity));

        CreateMap<ClientQueryResult, ClientWebReply<IEnumerable<ClientDto>>>()
            .ForMember(d => d.IsSuccess, opt => opt.MapFrom(src => src.IsSuccess))
            .ForMember(d => d.Data, opt => opt.MapFrom(src => src.Range));
    }
}