using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReqresClient.Services;
using ReqresClient.Services.Abstractions;

namespace ReqresClient;

public class App
{
    private readonly IUserService _userService;
    private readonly IRegisterService _registerService;
    private readonly ILogger<App> _logger;

    public App(IUserService userService, IRegisterService registerService, ILogger<App> logger)
    {
        _userService = userService;
        _registerService = registerService;
        _logger = logger;
    }

    public async Task Start()
    {
        var queryParams = new Dictionary<string, int> { { "page", 2 } };
        var delayQueryParams = new Dictionary<string, int> { { "page", 2 }, { "delay", 3 } };

        _logger.LogInformation("Start user endpoints-------------------------------------------");
        var users = await _userService.GetListOfUsers(queryParams);
        var user = await _userService.GetUserById(2);
        var userNotFound = await _userService.GetUserById(213);
        var userInfo = await _userService.CreateUser("morpheus", "leader");
        var userInfoUpdated = await _userService.UpdateUser(userInfo, "neo", "chosen");
        var userInfoPatched = await _userService.PatchUser(userInfo, "agent?");
        var isUserInfoDeleted = await _userService.DeleteUser(userInfo.Id);

        _logger.LogInformation("Start heavy request--------------------------------------------");
        var delayedUsers = await _userService.GetListOfUsers(delayQueryParams);
        _logger.LogInformation("End heavy request----------------------------------------------");

        var credentials = (Email: "eve.holt@reqres.in", Password: "cityslicka");

        _logger.LogInformation("Start auth endpoints-------------------------------------------");
        var registeredUser = await _registerService.Register(credentials.Email, credentials.Password);
        var registerFailed = await _registerService.RegisterFailed(credentials.Email);

        var loggedUser = await _registerService.Login(credentials.Email, credentials.Password);
        var loginFailed = await _registerService.LoginFailed(credentials.Email);
    }
}