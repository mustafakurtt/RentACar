using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.CreateRange;

public class CreateFuelRangeCommand : IRequest<CreatedFuelRangeListItemDto>
{
    public ICollection<string> Names { get; set; }
    public class CreateFuelRangeCommandHandler : IRequestHandler<CreateFuelRangeCommand, CreatedFuelRangeListItemDto>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public CreateFuelRangeCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<CreatedFuelRangeListItemDto> Handle(CreateFuelRangeCommand request, CancellationToken cancellationToken)
        {
            ICollection<Fuel> fuels = request.Names.Select(name => new Fuel() { Id = Guid.NewGuid(), Name = name}).ToList();
            fuels = await _fuelRepository.AddRangeAsync(fuels);
            var response = _mapper.Map<CreatedFuelRangeListItemDto>(fuels);
            return response;
        }
    }
}