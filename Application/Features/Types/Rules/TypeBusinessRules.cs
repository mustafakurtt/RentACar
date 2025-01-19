using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Type = Domain.Entities.Type;
namespace Application.Features.Types.Rules;

public class TypeBusinessRules : BaseBusinessRules
{
    private readonly ITypeRepository _typeRepository;

    public TypeBusinessRules(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }

    public async Task TypeNameCannotBeDuplicated(string name)
    {
        var type = await _typeRepository.GetAsync(b => b.Name.ToLower() == name.ToLower(),enableTracking:false);
        if (type != null)
            throw new BusinessException("Type name already exists");
    }

    //Check if entity exists 
    public async Task TypeMustExists(Guid id)
    {
        var type = await _typeRepository.GetAsync(t => t.Id == id);
        if (type == null)
            throw new BusinessException("Type not found");
    }

    public async Task TypeMustExists(string name)
    {
        var type = await _typeRepository.GetAsync(t => t.Name == name);
        if (type == null)
            throw new BusinessException("Type not found");
    }

    public Task TypeMustExists(Type? type)
    {
        if (type == null)
            throw new BusinessException("Type not found");
        return Task.CompletedTask;
    }

}