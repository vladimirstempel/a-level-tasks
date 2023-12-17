using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReqresClient.Services.Abstractions;

namespace ReqresClient.Services;

public sealed class InternalHttpClientService : IInternalHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;

    public InternalHttpClientService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
        where TRequest : class
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;

        if (content != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default;
    }

    public async Task<TResponse> GetAsync<TResponse>(string url)
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = HttpMethod.Get;

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default;
    }

    public async Task<TResponse> GetAsync<TResponse, TParams>(string url, Dictionary<string, TParams> queryParams = null)
    {
        var client = _clientFactory.CreateClient();

        var paramsString = BuildQueryParamsString(queryParams);
        url += !string.IsNullOrEmpty(paramsString) ? $"?{paramsString}" : string.Empty;

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = HttpMethod.Get;

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default;
    }

    public async Task<TResponse> PostAsync<TResponse, TBody>(string url, TBody body = default)
        where TBody : class
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = HttpMethod.Post;

        if (body != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode || result.StatusCode == HttpStatusCode.BadRequest)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default;
    }

    public async Task<TResponse> PostAsync<TResponse, TBody, TParams>(string url, TBody body = default, Dictionary<string, TParams> queryParams = null)
        where TBody : class
    {
        var client = _clientFactory.CreateClient();

        var paramsString = BuildQueryParamsString(queryParams);
        url += !string.IsNullOrEmpty(paramsString) ? $"?{paramsString}" : string.Empty;

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = HttpMethod.Post;

        if (body != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default;
    }

    public async Task<TResponse> PutAsync<TResponse, TBody>(string url, TBody body = default)
        where TBody : class
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = HttpMethod.Put;

        if (body != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default;
    }

    public async Task<TResponse> PutAsync<TResponse, TBody, TParams>(string url, TBody body = default, Dictionary<string, TParams> queryParams = null)
        where TBody : class
    {
        var client = _clientFactory.CreateClient();

        var paramsString = BuildQueryParamsString(queryParams);
        url += !string.IsNullOrEmpty(paramsString) ? $"?{paramsString}" : string.Empty;

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = HttpMethod.Put;

        if (body != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default;
    }

    public async Task<TResponse> PatchAsync<TResponse, TBody>(string url, TBody body = default)
        where TBody : class
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = HttpMethod.Patch;

        if (body != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default;
    }

    public async Task<TResponse> PatchAsync<TResponse, TBody, TParams>(string url, TBody body = default, Dictionary<string, TParams> queryParams = null)
        where TBody : class
    {
        var client = _clientFactory.CreateClient();

        var paramsString = BuildQueryParamsString(queryParams);
        url += !string.IsNullOrEmpty(paramsString) ? $"?{paramsString}" : string.Empty;

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = HttpMethod.Patch;

        if (body != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default;
    }

    public async Task<bool> DeleteAsync(string url)
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = HttpMethod.Delete;

        var result = await client.SendAsync(httpMessage);

        return result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.NoContent;
    }

    private string BuildQueryParamsString<TParam>(Dictionary<string, TParam> queryParams)
    {
        var paramStrings = queryParams
            .Select(param => $"{param.Key}={param.Value}")
            .ToList();
        return paramStrings.Count > 0 ? string.Join("&", paramStrings) : string.Empty;
    }
}