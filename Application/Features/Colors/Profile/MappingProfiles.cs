using Application.Features.Brands.Commands.CreateRange;
using Application.Features.Brands.Queries.GetList;
using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.CreateRange;
using Application.Features.Colors.Queries.GetList;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Colors.Profile;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<Color, CreateColorCommand>().ReverseMap();
        CreateMap<Color, CreatedColorResponse>().ReverseMap();

        CreateMap<Color, CreatedColorRangeListItemDto>().ReverseMap();

        CreateMap<Paginate<Color>, GetListResponse<GetListColorListItemDto>>().ReverseMap();
        CreateMap<Color, GetListColorListItemDto>().ReverseMap();
    }
}