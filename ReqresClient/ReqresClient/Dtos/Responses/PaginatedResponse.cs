using Newtonsoft.Json;

namespace ReqresClient.Dtos.Responses;

public class PaginatedResponse<T> : BaseResponse<T>
    where T : class
{
    public int? Page { get; set; }
    public int? Total { get; set; }

    [JsonProperty(PropertyName = "per_page")]
    public int PerPage { get; set; }

    [JsonProperty(PropertyName = "total_pages")]
    public int TotalPages { get; set; }
}