using Application.Features.Types.Commands.Create;
using Application.Features.Types.Commands.CreateRange;
using Application.Features.Types.Queries.GetList;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Type = Domain.Entities.Type;

namespace Application.Features.Types.Profile;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Type, CreateTypeCommand>().ReverseMap();
        CreateMap<Type, CreatedTypeResponse>().ReverseMap();

        CreateMap<Type, CreatedTypeRangeListItemDto>().ReverseMap();

        CreateMap<Paginate<Type>, GetListResponse<GetListTypeListItemDto>>().ReverseMap();
        CreateMap<Type, GetListTypeListItemDto>().ReverseMap();
    }   
}