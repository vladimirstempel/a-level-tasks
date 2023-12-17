using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReqresClient.Config;
using ReqresClient.Dtos;
using ReqresClient.Dtos.Requests;
using ReqresClient.Dtos.Responses;
using ReqresClient.Services.Abstractions;

namespace ReqresClient.Services;

public class UserService : IUserService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;
    private readonly string _userApi = "api/users/";

    public UserService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<List<UserDto>> GetListOfUsers<TParam>(Dictionary<string, TParam> queryParams)
    {
        var result = await _httpClientService
            .GetAsync<PaginatedResponse<List<UserDto>>, TParam>($"{_options.Host}{_userApi}", queryParams);

        if (result?.Data != null)
        {
            var userIdList = result.Data.Select(user => user.Id).ToList();
            _logger.LogInformation("User list was received = {0} (Page = {1}, Per Page = {2}, Total Pages = {3})", string.Join(", ", userIdList), result.Page, result.PerPage, result.TotalPages);
        }

        return result?.Data;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var result =
            await _httpClientService.GetAsync<BaseResponse<UserDto>>($"{_options.Host}{_userApi}{id}");

        _logger.LogInformation(result?.Data != null
            ? $"User with id = {result.Data.Id} was found"
            : $"User with id = {id} not found");

        return result?.Data;
    }

    public async Task<UserResponse> CreateUser(string name, string job)
    {
        var result = await _httpClientService.PostAsync<UserResponse, UserRequest>(
            $"{_options.Host}{_userApi}",
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation("User with id = {0} ({1}, {2}) was created", result.Id, result.Name, result.Job);
        }

        return result;
    }

    public async Task<UserResponse> UpdateUser(UserResponse user, string name, string job)
    {
        user.Name = name;
        user.Job = job;

        var result = await _httpClientService.PutAsync<UserResponse, UserResponse>($"{_options.Host}{_userApi}{user.Id}", user);

        if (result != null)
        {
            _logger.LogInformation("User with id = {0} ({1}, {2}) was updated", result.Id, result.Name, result.Job);
        }

        return result;
    }

    public async Task<UserResponse> PatchUser(UserResponse user, string job)
    {
        user.Job = job;

        var result = await _httpClientService.PatchAsync<UserResponse, UserResponse>($"{_options.Host}{_userApi}{user.Id}", user);

        if (result != null)
        {
            _logger.LogInformation("User with id = {0} ({1}, {2}) was patched", result.Id, result.Name, result.Job);
        }

        return result;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var result = await _httpClientService.DeleteAsync($"{_options.Host}{_userApi}{id}");

        if (result)
        {
            _logger.LogInformation("User with id = {0} has been deleted", id);
        }

        return result;
    }
}