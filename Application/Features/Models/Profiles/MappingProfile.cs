using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.CreateRange;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Model, CreateModelCommand>().ReverseMap();

        CreateMap<Model, CreatedModelResponse>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel.Name))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name))
            .ReverseMap();

        CreateMap<Model, CreateModelRangeRequest>().ReverseMap();
        CreateMap<Model, CreatedModelRangeListItemDto>().ReverseMap();

        CreateMap<Model,GetListModelListItemDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel.Name))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name))
            .ReverseMap(); ;
        CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();

        CreateMap<Model, GetListByDynamicQueryListItemDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel.Name))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name))
            .ReverseMap(); ;
        CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicQueryListItemDto>>().ReverseMap();

    }
}