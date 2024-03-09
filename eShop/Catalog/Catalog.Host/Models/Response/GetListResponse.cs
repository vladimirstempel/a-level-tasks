namespace Catalog.Host.Models.Response;

public class GetListResponse<T>
{
    public List<T> Data { get; set; } = new ();
}