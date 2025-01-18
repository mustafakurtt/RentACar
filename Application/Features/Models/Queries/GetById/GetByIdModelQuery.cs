using Application.Features.Models.Commands.Create;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelQuery : IRequest<GetByIdModelResponse>
{
    public Guid Id { get; set; }

    public class GetByIdModelQueryHandler : IRequestHandler<GetByIdModelQuery,GetByIdModelResponse>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetByIdModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdModelResponse> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
        {
            var model = await _modelRepository.GetAsync(
                predicate:x => x.Id == request.Id,
                cancellationToken:cancellationToken,
                include: m => 
                    m.Include(m => m.Color)
                        .Include(m => m.Brand)
                        .Include(m => m.Transmission)
                        .Include(m => m.Type)
                        .Include(m => m.Fuel));
            var result = _mapper.Map<GetByIdModelResponse>(model);
            return result;
        }
    }
}