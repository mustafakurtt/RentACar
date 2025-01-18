using Application.Features.Models.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListByDynamic;

public class GetListByDynamicQuery : IRequest<GetListResponse<GetListByDynamicQueryListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicQueryHandler : IRequestHandler<GetListByDynamicQuery, GetListResponse<GetListByDynamicQueryListItemDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDynamicQueryListItemDto>> Handle(GetListByDynamicQuery request, CancellationToken cancellationToken)
        {
            Paginate<Model> models = await _modelRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: m =>
                    m.Include(m => m.Color)
                        .Include(m => m.Brand)
                        .Include(m => m.Transmission)
                        .Include(m => m.Type)
                        .Include(m => m.Fuel));

            var result = _mapper.Map<GetListResponse<GetListByDynamicQueryListItemDto>>(models);
            return result;
        }
    }
}