using Application.Features.Types.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Type = Domain.Entities.Type;

namespace Application.Features.Types.Commands.Update;

public class UpdateTypeCommand : IRequest<UpdatedTypeResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand, UpdatedTypeResponse>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;
        private readonly TypeBusinessRules _typeBusinessRules;

        public UpdateTypeCommandHandler(ITypeRepository typeRepository, IMapper mapper, TypeBusinessRules typeBusinessRules)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
            _typeBusinessRules = typeBusinessRules;
        }

        public async Task<UpdatedTypeResponse> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _typeRepository.GetAsync(t => t.Id == request.Id);
            
            await _typeBusinessRules.TypeMustExists(type);
            await _typeBusinessRules.TypeNameCannotBeDuplicated(request.Name);

            type.Name = request.Name;

            await _typeRepository.UpdateAsync(type);

            var result = _mapper.Map<UpdatedTypeResponse>(type);
            
            return result;

        }
    }
}