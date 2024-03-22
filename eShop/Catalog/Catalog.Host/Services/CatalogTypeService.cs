using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly IMapper _mapper;

    public CatalogTypeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
        _mapper = mapper;
    }

    public async Task<int?> Add(string type)
    {
        return await ExecuteSafeAsync(() => _catalogTypeRepository.Add(type));
    }

    public async Task<int?> Update(int id, string type)
    {
        return await ExecuteSafeAsync(() => _catalogTypeRepository.Update(id, type));
    }

    public async Task<int?> Delete(int id)
    {
        return await ExecuteSafeAsync(() => _catalogTypeRepository.Delete(id));
    }
}