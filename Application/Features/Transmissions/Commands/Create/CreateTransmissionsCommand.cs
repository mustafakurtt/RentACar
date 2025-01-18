using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.Create;

public class CreateTransmissionsCommand : IRequest<CreatedTransmissionsResponse>
{
    public string Name { get; set; }
    
    public class CreateTransmissionsCommandHandler : IRequestHandler<CreateTransmissionsCommand, CreatedTransmissionsResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public CreateTransmissionsCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository)
        {
            _mapper = mapper;
            _transmissionRepository = transmissionRepository;
        }

        public async Task<CreatedTransmissionsResponse> Handle(CreateTransmissionsCommand request, CancellationToken cancellationToken)
        {
            var transmission = _mapper.Map<Transmission>(request);
            transmission.Id = Guid.NewGuid();
            await _transmissionRepository.AddAsync(transmission);

            var response = _mapper.Map<CreatedTransmissionsResponse>(transmission);
            return response;
        }
    }
}