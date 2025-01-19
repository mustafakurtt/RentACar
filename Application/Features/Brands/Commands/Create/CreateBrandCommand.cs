using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ITransactionalRequest , ICacheRemoverRequest
{
    public string Name { get; set; }

    public string? CacheKey => null;
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetBrands";

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand,CreatedBrandResponse>

    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            //await _brandBusinessRules.BrandNameCannotBeDuplicated(request.Name);


            Brand brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();

            var createdBrand = await _brandRepository.AddAsync(brand);
            var createdBrandResponse = _mapper.Map<CreatedBrandResponse>(createdBrand);
            return createdBrandResponse;
        }
    }


}