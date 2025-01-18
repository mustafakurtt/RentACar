using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.Create;

public class CreateColorCommand : IRequest<CreatedColorResponse>
{
    public string Name { get; set; }
    
    public class CreateColorCommandHandler :  IRequestHandler<CreateColorCommand, CreatedColorResponse>
    {
        private IColorRepository _colorRepository;
        private IMapper _mapper;

        public CreateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<CreatedColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            Color color = _mapper.Map<Color>(request);
            color.Id = Guid.NewGuid();
            color = await _colorRepository.AddAsync(color);
            return _mapper.Map<CreatedColorResponse>(color);
        }
    }
}