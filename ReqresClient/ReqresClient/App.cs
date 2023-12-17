using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReqresClient.Services.Abstractions;

namespace ReqresClient;

public class App
{
    private readonly IUserService _userService;
    private readonly IRegisterService _registerService;

    public App(IUserService userService, IRegisterService registerService)
    {
        _userService = userService;
        _registerService = registerService;
    }

    public async Task Start()
    {
        var queryParams = new Dictionary<string, int> { { "page", 2 } };
        var delayQueryParams = new Dictionary<string, int> { { "page", 2 }, { "delay", 3 } };

        Console.WriteLine("Start user endpoints-------------------------------------------");
        var users = await _userService.GetListOfUsers(queryParams);
        var user = await _userService.GetUserById(2);
        var userNotFound = await _userService.GetUserById(213);
        var userInfo = await _userService.CreateUser("morpheus", "leader");
        var userInfoUpdated = await _userService.UpdateUser(userInfo, "neo", "chosen");
        var userInfoPatched = await _userService.PatchUser(userInfo, "agent?");
        var isUserInfoDeleted = await _userService.DeleteUser(userInfo.Id);

        Console.WriteLine("Start heavy request--------------------------------------------");
        var delayedUsers = await _userService.GetListOfUsers(delayQueryParams);
        Console.WriteLine("End heavy request----------------------------------------------");

        var credentials = (Email: "eve.holt@reqres.in", Password: "cityslicka");

        Console.WriteLine("Start auth endpoints-------------------------------------------");
        var registeredUser = await _registerService.Register(credentials.Email, credentials.Password);
        var registerFailed = await _registerService.RegisterFailed(credentials.Email);

        var loggedUser = await _registerService.Login(credentials.Email, credentials.Password);
        var loginFailed = await _registerService.LoginFailed(credentials.Email);
    }
}