using Core.Persistence.Repositories;
using Type = Domain.Entities.Type;

namespace Application.Services.Repositories;

public interface ITypeRepository : IAsyncRepository<Type,Guid>, IRepository<Type, Guid>
{
}