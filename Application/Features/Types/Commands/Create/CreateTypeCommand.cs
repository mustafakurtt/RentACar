using Application.Features.Types.Commands.Create;
using Application.Features.Types.Rules;
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
        private TypeBusinessRules _typeBusinessRules;

        public CreateTypeCommandHandler(ITypeRepository typeRepository, IMapper mapper, TypeBusinessRules typeBusinessRules)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
            _typeBusinessRules = typeBusinessRules;
        }

        public async Task<CreatedTypeResponse> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {

            await _typeBusinessRules.TypeNameCannotBeDuplicated(request.Name);

            Type type = _mapper.Map<Type>(request);
            type.Id = Guid.NewGuid();
            type = await _typeRepository.AddAsync(type);
            return _mapper.Map<CreatedTypeResponse>(type);
        }
    }
}