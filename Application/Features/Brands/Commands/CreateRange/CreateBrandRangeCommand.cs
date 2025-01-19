using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateRange;

public class CreateBrandRangeCommand : IRequest<ICollection<CreateBrandRangeListItemDto>>
{
    public ICollection<string> BrandNames { get; set; }

    public class CreateRangeBrandCommandHandler : IRequestHandler<CreateBrandRangeCommand, ICollection<CreateBrandRangeListItemDto>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;
        public CreateRangeBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }
        public async Task<ICollection<CreateBrandRangeListItemDto>> Handle(CreateBrandRangeCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenCreateRange(request.BrandNames);
            ICollection<Brand> brands = request.BrandNames.Select(name => new Brand { Name = name, Id = Guid.NewGuid()}).ToList();
            ICollection<Brand> createdBrands = await _brandRepository.AddRangeAsync(brands);
            ICollection<CreateBrandRangeListItemDto> createdBrandsResponse = _mapper.Map<List<CreateBrandRangeListItemDto>>(createdBrands);
            return createdBrandsResponse;
        }
    }
}