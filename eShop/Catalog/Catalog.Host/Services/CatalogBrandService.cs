using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly IMapper _mapper;

    public CatalogBrandService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogBrandRepository catalogBrandRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _mapper = mapper;
    }

    public async Task<int?> Add(string brand)
    {
        return await ExecuteSafeAsync(() => _catalogBrandRepository.Add(brand));
    }

    public async Task<int?> Update(int id, string brand)
    {
        return await ExecuteSafeAsync(() => _catalogBrandRepository.Update(id, brand));
    }

    public async Task<int?> Delete(int id)
    {
        return await ExecuteSafeAsync(() => _catalogBrandRepository.Delete(id));
    }
}