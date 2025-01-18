using Application.Features.Transmissions.Queries.GetList;
using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.CreateRange;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Transmissions.Profile;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<Transmission, CreateTransmissionsCommand>().ReverseMap();
        CreateMap<Transmission, CreatedTransmissionsResponse>().ReverseMap();

        CreateMap<Transmission, CreatedTransmissionRangeListItemDto>().ReverseMap();

        CreateMap<Paginate<Transmission>, GetListResponse<GetListTransmissionListItemDto>>().ReverseMap();
        CreateMap<Transmission, GetListTransmissionListItemDto>().ReverseMap();

    }
    
}