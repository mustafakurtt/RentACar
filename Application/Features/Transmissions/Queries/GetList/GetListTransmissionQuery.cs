using Application.Features.Transmissions.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Queries.GetList;

public class GetListTransmissionQuery : IRequest<GetListResponse<GetListTransmissionListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTransmissionQueryHandler : IRequestHandler<GetListTransmissionQuery, GetListResponse<GetListTransmissionListItemDto>>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public GetListTransmissionQueryHandler(IMapper mapper, ITransmissionRepository transmissionRepository)
        {
            _mapper = mapper;
            _transmissionRepository = transmissionRepository;
        }

        public async Task<GetListResponse<GetListTransmissionListItemDto>> Handle(GetListTransmissionQuery request, CancellationToken cancellationToken)
        {
            Paginate<Transmission> transmissions = await _transmissionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

            GetListResponse<GetListTransmissionListItemDto> response =
                _mapper.Map<GetListResponse<GetListTransmissionListItemDto>>(transmissions);

            return response;
        }
    }
}