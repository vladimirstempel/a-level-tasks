namespace Catalog.Host.Models.Response;

public class GetByIdResponse<T>
{
    public T Data { get; set; } = default(T) !;
}