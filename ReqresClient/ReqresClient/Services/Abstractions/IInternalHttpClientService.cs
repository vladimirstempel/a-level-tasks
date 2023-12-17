using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReqresClient.Services.Abstractions;

public interface IInternalHttpClientService
{
    Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
        where TRequest : class;
    Task<TResponse> GetAsync<TResponse>(string url);
    Task<TResponse> GetAsync<TResponse, TParams>(string url, Dictionary<string, TParams> queryParams = null);
    Task<TResponse> PostAsync<TResponse, TBody>(string url, TBody body = null)
        where TBody : class;
    Task<TResponse> PostAsync<TResponse, TBody, TParams>(string url, TBody body = null, Dictionary<string, TParams> queryParams = null)
        where TBody : class;
    Task<TResponse> PutAsync<TResponse, TBody>(string url, TBody body = null)
        where TBody : class;
    Task<TResponse> PutAsync<TResponse, TBody, TParams>(string url, TBody body = null, Dictionary<string, TParams> queryParams = null)
        where TBody : class;
    Task<TResponse> PatchAsync<TResponse, TBody>(string url, TBody body = null)
        where TBody : class;
    Task<TResponse> PatchAsync<TResponse, TBody, TParams>(string url, TBody body = null, Dictionary<string, TParams> queryParams = null)
        where TBody : class;
    Task<bool> DeleteAsync(string url);
}