using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Commands.CreateRange;

public class CreateModelRangeCommand : IRequest<ICollection<CreatedModelRangeListItemDto>>
{
    public ICollection<CreateModelRangeRequest> Models { get; set; }

    public class CreateModelRangeCommandHandler : IRequestHandler<CreateModelRangeCommand, ICollection<CreatedModelRangeListItemDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public CreateModelRangeCommandHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CreatedModelRangeListItemDto>> Handle(CreateModelRangeCommand request, CancellationToken cancellationToken)
        {
            ICollection<Model> models = _mapper.Map<ICollection<Model>>(request.Models);
            await _modelRepository.AddRangeAsync(models);
            var createdModels = await _modelRepository.GetListAsync(
                predicate: x => models.Select(m => m.Id).Contains(x.Id),
                include: m => 
                    m.Include(m => m.Brand)
                        .Include(m => m.Color)
                        .Include(m => m.Fuel)
                        .Include(m => m.Transmission)
                        .Include(m => m.Type)
            );
            var result = _mapper.Map<ICollection<CreatedModelRangeListItemDto>>(createdModels.Items);
            return result;


        }
    }
}