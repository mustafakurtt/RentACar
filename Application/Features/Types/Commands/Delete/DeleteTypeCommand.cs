using Application.Features.Types.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Type = Domain.Entities.Type;

namespace Application.Features.Types.Commands.Delete;

public class DeleteTypeCommand : IRequest<DeletedTypeResponse>
{
    public Guid Id { get; set; }

    public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand, DeletedTypeResponse>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;
        private readonly TypeBusinessRules _typeBusinessRules;

        public DeleteTypeCommandHandler(ITypeRepository typeRepository, IMapper mapper, TypeBusinessRules typeBusinessRules)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
            _typeBusinessRules = typeBusinessRules;
        }

        public async Task<DeletedTypeResponse> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _typeRepository.GetAsync(predicate: t => t.Id == request.Id,cancellationToken: cancellationToken);
            await _typeBusinessRules.TypeMustExists(type);

            type = await _typeRepository.DeleteAsync(type);
            var result = _mapper.Map<DeletedTypeResponse>(type);
            return result;
        }
    }
}