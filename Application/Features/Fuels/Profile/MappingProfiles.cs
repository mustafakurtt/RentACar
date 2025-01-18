using Application.Features.Colors.Queries.GetList;
using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.CreateRange;
using Application.Features.Fuels.Queries.GetList;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Fuels.Profile;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<Fuel, CreatedFuelResponse>().ReverseMap();
        CreateMap<Fuel, CreateFuelCommand>().ReverseMap();

        CreateMap<Fuel, CreatedFuelRangeListItemDto>().ReverseMap();

        CreateMap<Paginate<Fuel>, GetListResponse<GetListFuelListItemDto>>().ReverseMap();
        CreateMap<Fuel, GetListFuelListItemDto>().ReverseMap();
    }
}