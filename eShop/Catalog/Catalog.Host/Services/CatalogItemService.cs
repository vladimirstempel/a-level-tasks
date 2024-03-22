using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<int?> Add(CatalogItem item)
    {
        return await ExecuteSafeAsync(() => _catalogItemRepository.Add(
            item.Name,
            item.Description,
            item.Price,
            item.AvailableStock,
            item.CatalogTypeId,
            item.CatalogBrandId,
            item.PictureFileName));
    }

    public async Task<int?> Update(int id, CatalogItem item)
    {
        return await ExecuteSafeAsync(() => _catalogItemRepository.Update(
            id,
            item.Name,
            item.Description,
            item.Price,
            item.AvailableStock,
            item.CatalogTypeId,
            item.CatalogBrandId,
            item.PictureFileName));
    }

    public async Task<int?> Delete(int id)
    {
        return await ExecuteSafeAsync(() => _catalogItemRepository.Delete(id));
    }
}