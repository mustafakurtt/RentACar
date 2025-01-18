using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.CreateRange;

public class CreateTransmissionRangeCommand : IRequest<ICollection<CreatedTransmissionRangeListItemDto>>
{
    public ICollection<string> Names { get; set; }

    public class CreateTransmissionRangeCommandHandler : IRequestHandler<CreateTransmissionRangeCommand, ICollection<CreatedTransmissionRangeListItemDto>>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public CreateTransmissionRangeCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CreatedTransmissionRangeListItemDto>> Handle(CreateTransmissionRangeCommand request, CancellationToken cancellationToken)
        {
            ICollection<Transmission> transmissions = request.Names.Select(name => new Transmission { Id = Guid.NewGuid() ,Name = name }).ToList();
            transmissions = await _transmissionRepository.AddRangeAsync(transmissions);
            ICollection<CreatedTransmissionRangeListItemDto> response = _mapper.Map<ICollection<CreatedTransmissionRangeListItemDto>>(transmissions);
            return response;
        }
    }
}