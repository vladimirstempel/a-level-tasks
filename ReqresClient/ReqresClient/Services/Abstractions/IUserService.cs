using System.Collections.Generic;
using System.Threading.Tasks;
using ReqresClient.Dtos;
using ReqresClient.Dtos.Responses;

namespace ReqresClient.Services.Abstractions;

public interface IUserService
{
    Task<List<UserDto>> GetListOfUsers<TParam>(Dictionary<string, TParam> queryParams);
    Task<UserDto> GetUserById(int id);
    Task<UserResponse> CreateUser(string name, string job);
    Task<UserResponse> UpdateUser(UserResponse user, string name, string job);
    Task<UserResponse> PatchUser(UserResponse user, string job);
    Task<bool> DeleteUser(int id);
}