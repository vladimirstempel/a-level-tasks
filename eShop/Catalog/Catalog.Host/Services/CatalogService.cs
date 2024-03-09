using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<GetByIdResponse<CatalogItemDto>> GetCatalogItemByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByIdAsync(id);
            return new GetByIdResponse<CatalogItemDto>()
            {
                Data = _mapper.Map<CatalogItemDto>(result)
            };
        });
    }

    public async Task<GetListResponse<CatalogItemDto>> GetCatalogItemsByTypeAsync(string type)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByTypeAsync(type);
            return new GetListResponse<CatalogItemDto>()
            {
                Data = result.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList()
            };
        });
    }

    public async Task<GetListResponse<CatalogItemDto>> GetCatalogItemsByBrandAsync(string brand)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByBrandAsync(brand);
            return new GetListResponse<CatalogItemDto>()
            {
                Data = result.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList()
            };
        });
    }

    public async Task<GetListResponse<CatalogBrandDto>> GetBrandsAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetBrandsAsync();
            return new GetListResponse<CatalogBrandDto>()
            {
                Data = result.Select(s => _mapper.Map<CatalogBrandDto>(s)).ToList()
            };
        });
    }

    public async Task<GetListResponse<CatalogTypeDto>> GetTypesAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetTypesAsync();
            return new GetListResponse<CatalogTypeDto>()
            {
                Data = result.Select(s => _mapper.Map<CatalogTypeDto>(s)).ToList()
            };
        });
    }
}