using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand : IRequest<UpdatedBrandResponse> ,ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string? CacheKey => null;
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetBrands";

    public class UpdateBrandCommandHandler: IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, withDeleted: false,
                cancellationToken: cancellationToken);
            if (brand == null)
                throw new Exception("Brand Not Found");

            brand = _mapper.Map(request, brand);
            brand = await _brandRepository.UpdateAsync(brand);
            UpdatedBrandResponse updatedBrandResponse = _mapper.Map<UpdatedBrandResponse>(brand);
            return updatedBrandResponse;

        }
    }


}