using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<GetByIdResponse<CatalogItemDto>> GetCatalogItemByIdAsync(int id);
    Task<GetListResponse<CatalogItemDto>> GetCatalogItemsByTypeAsync(string type);
    Task<GetListResponse<CatalogItemDto>> GetCatalogItemsByBrandAsync(string brand);
    Task<GetListResponse<CatalogTypeDto>> GetTypesAsync();
    Task<GetListResponse<CatalogBrandDto>> GetBrandsAsync();
}