using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Persistence.Contexts;
using Type = Domain.Entities.Type;

namespace Persistence.Repositories;

public class TypeRepository : EfRepositoryBase<Type, Guid, BaseDbContext>, ITypeRepository
{
    public TypeRepository(BaseDbContext context) : base(context)
    {
    }
}