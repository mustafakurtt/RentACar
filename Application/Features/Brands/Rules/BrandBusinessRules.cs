using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules : BaseBusinessRules
{
    private IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCannotBeDuplicated(string name)
    {
        var brand = await _brandRepository.GetAsync(b => b.Name.ToLower() == name.ToLower());
        if (brand != null)
            throw new BusinessException(BrandsMessages.BrandNameExists);
        
    }

    public async Task BrandNameCannotBeDuplicatedWhenCreateRange(ICollection<string> names)
    {
        var brands = await _brandRepository.GetListAsync(b => names.Contains(b.Name));
        var existsBrandNames = brands.Items.Select(b => b.Name).ToList();
        if (existsBrandNames.Any())
            throw new BusinessException(string.Format(BrandsMessages.BrandNameExists +":"+  string.Join(",", existsBrandNames)));
    }
} 