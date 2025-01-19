using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand : IRequest<DeletedBrandResponse> , ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string? CacheKey => null;
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetBrands";

    public class DeletedBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeletedBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, withDeleted: false,
                cancellationToken: cancellationToken);

            if (brand == null)
                throw new Exception("Brand Not Found");

             brand = await _brandRepository.DeleteAsync(brand);
            DeletedBrandResponse deletedBrandResponse = _mapper.Map<DeletedBrandResponse>(brand);
            return deletedBrandResponse;
        }
    }


}