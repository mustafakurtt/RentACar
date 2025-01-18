using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand : IRequest<CreatedModelResponse>
{
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid ColorId { get; set; }
    public Guid TransmissionId { get; set; }
    public Guid TypeId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }

    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            Model model = _mapper.Map<Model>(request);
            model.Id = Guid.NewGuid();
            await _modelRepository.AddAsync(model);

            Model createdModel = await _modelRepository.GetAsync(
                x => x.Id == model.Id,
                include: m =>
                    m.Include(m => m.Brand)
                        .Include(m => m.Color)
                        .Include(m => m.Fuel)
                        .Include(m => m.Transmission)
                        .Include(m => m.Type)
            );

            var result = _mapper.Map<CreatedModelResponse>(createdModel);
            return result;
        }
    }
}