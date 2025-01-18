using Application.Features.Types.Commands.CreateRange;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Type = Domain.Entities.Type;

namespace Application.Features.Types.Commands.CreateRange;

public class CreateTypeRangeCommand : IRequest<ICollection<CreatedTypeRangeListItemDto>>
{
    public ICollection<string> Names { get; set; }

    public class CreateTypeRangeCommandHandler : IRequestHandler<CreateTypeRangeCommand, ICollection<CreatedTypeRangeListItemDto>>
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public CreateTypeRangeCommandHandler(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CreatedTypeRangeListItemDto>> Handle(CreateTypeRangeCommand request, CancellationToken cancellationToken)
        {
            ICollection<Type> types = request.Names.Select(name => new Type { Id = Guid.NewGuid(), Name = name }).ToList();
            types = await _typeRepository.AddRangeAsync(types);
            ICollection<CreatedTypeRangeListItemDto> createdTypesResponse = _mapper.Map<ICollection<CreatedTypeRangeListItemDto>>(types);
            return createdTypesResponse;
        }
    }
}