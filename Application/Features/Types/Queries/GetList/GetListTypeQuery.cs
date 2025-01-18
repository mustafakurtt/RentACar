using Application.Features.Types.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using Type = Domain.Entities.Type;

namespace Application.Features.Types.Queries.GetList;

public class GetListTypeQuery : IRequest<GetListResponse<GetListTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTypeQueryHandler : IRequestHandler<GetListTypeQuery, GetListResponse<GetListTypeListItemDto>>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public GetListTypeQueryHandler(IMapper mapper, ITypeRepository typeRepository)
        {
            _mapper = mapper;
            _typeRepository = typeRepository;
        }

        public async Task<GetListResponse<GetListTypeListItemDto>> Handle(GetListTypeQuery request, CancellationToken cancellationToken)
        {
            Paginate<Type> types = await _typeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

            GetListResponse<GetListTypeListItemDto> response =
                _mapper.Map<GetListResponse<GetListTypeListItemDto>>(types);

            return response;
        }
    }
}