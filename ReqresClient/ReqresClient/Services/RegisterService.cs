using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReqresClient.Config;
using ReqresClient.Dtos.Requests;
using ReqresClient.Dtos.Responses;
using ReqresClient.Services.Abstractions;

namespace ReqresClient.Services;

public class RegisterService : IRegisterService
{
    private const string RegisterApi = "api/register";
    private const string LoginApi = "api/login";

    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;

    public RegisterService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<RegisterResponse> Register(string email, string password)
    {
        var result = await _httpClientService
            .PostAsync<RegisterResponse, AuthRequest>(
                $"{_options.Host}{RegisterApi}",
                new AuthRequest
                {
                    Email = email, Password = password
                });

        if (result != null)
        {
            _logger.LogInformation(
                $"Register successful (Id = {result.Id}, Token = {result.Token})");
        }

        return result;
    }

    public async Task<ErrorResponse> RegisterFailed(string email)
    {
        var result = await _httpClientService
            .PostAsync<ErrorResponse, AuthRequest>(
                $"{_options.Host}{RegisterApi}",
                new AuthRequest
                {
                    Email = email
                });

        if (result != null)
        {
            _logger.LogInformation(
                $"Register failed (Error: {result.Error})");
        }

        return result;
    }

    public async Task<LoginResponse> Login(string email, string password)
    {
        var result = await _httpClientService
            .PostAsync<LoginResponse, AuthRequest>(
                $"{_options.Host}{LoginApi}",
                new AuthRequest
                {
                    Email = email, Password = password
                });

        if (result != null)
        {
            _logger.LogInformation(
                $"Login successful (Token = {result.Token})");
        }

        return result;
    }

    public async Task<ErrorResponse> LoginFailed(string email)
    {
        var result = await _httpClientService
            .PostAsync<ErrorResponse, AuthRequest>(
                $"{_options.Host}{LoginApi}",
                new AuthRequest
                {
                    Email = email
                });

        if (result != null)
        {
            _logger.LogInformation(
                $"Login failed (Error: {result.Error})");
        }

        return result;
    }
}