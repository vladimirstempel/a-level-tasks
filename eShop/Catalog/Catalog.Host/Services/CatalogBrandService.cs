using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly IRepository<CatalogBrand> _catalogBrandRepository;
    private readonly IMapper _mapper;

    public CatalogBrandService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IRepository<CatalogBrand> catalogBrandRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _mapper = mapper;
    }

    public async Task<int?> Add(CreateBrandRequest item)
    {
        return await ExecuteSafeAsync(() => _catalogBrandRepository.Add(new CatalogBrand()
        {
            Brand = item.Brand
        }));
    }

    public async Task<int?> Update(int id, CreateBrandRequest item)
    {
        return await ExecuteSafeAsync(() => _catalogBrandRepository.Update(id, new CatalogBrand()
        {
            Id = id,
            Brand = item.Brand
        }));
    }

    public async Task<int?> Delete(int id)
    {
        return await ExecuteSafeAsync(() => _catalogBrandRepository.Delete(id));
    }
}