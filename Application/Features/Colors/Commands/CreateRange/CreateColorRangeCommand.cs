using System.Collections;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.CreateRange;

public class CreateColorRangeCommand : IRequest<ICollection<CreatedColorRangeListItemDto>>
{
    public ICollection<string> Names { get; set; }

    public class CreateColorRangeCommandHandler : IRequestHandler<CreateColorRangeCommand, ICollection<CreatedColorRangeListItemDto>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public CreateColorRangeCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CreatedColorRangeListItemDto>> Handle(CreateColorRangeCommand request, CancellationToken cancellationToken)
        {
            ICollection<Color> colors = request.Names.Select(name => new Color { Id = Guid.NewGuid(), Name = name }).ToList();
            colors = await _colorRepository.AddRangeAsync(colors);
            ICollection<CreatedColorRangeListItemDto>  createdColorsResponse =  _mapper.Map<ICollection<CreatedColorRangeListItemDto>>(colors);
            return createdColorsResponse;
        }
    }
}