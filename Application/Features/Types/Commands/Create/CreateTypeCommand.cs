using Application.Features.Types.Commands.Create;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Type = Domain.Entities.Type;

namespace Application.Features.Types.Commands.Create;

public class CreateTypeCommand : IRequest<CreatedTypeResponse>
{
    public string Name { get; set; }

    public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, CreatedTypeResponse>
    {
        private ITypeRepository _typeRepository;
        private IMapper _mapper;

        public CreateTypeCommandHandler(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<CreatedTypeResponse> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            Type type = _mapper.Map<Type>(request);
            type.Id = Guid.NewGuid();
            type = await _typeRepository.AddAsync(type);
            return _mapper.Map<CreatedTypeResponse>(type);
        }
    }
}