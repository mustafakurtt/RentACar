﻿using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetById;

public class GetByIdBrandQuery : IRequest<GetByIdBrandResponse>
{
    public Guid Id { get; set; }
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, GetByIdBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdBrandResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id, withDeleted: false,cancellationToken: cancellationToken);
            if (brand == null)
                throw new Exception("Brand not found");

            GetByIdBrandResponse brandResponse = _mapper.Map<GetByIdBrandResponse>(brand);
            return brandResponse;
        }
    }
}