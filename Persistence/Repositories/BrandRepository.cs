using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BrandRepository : EfRepositoryBase<Brand,Guid,BaseDBContext>, IBrandRepository
{
    public BrandRepository(BaseDBContext context) : base(context)
    {
    }
}