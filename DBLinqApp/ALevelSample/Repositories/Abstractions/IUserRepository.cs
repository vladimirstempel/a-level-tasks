using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Models;

namespace ALevelSample.Repositories.Abstractions;

public interface IUserRepository
{
    Task<string> AddUserAsync(string firstName, string lastName);
    Task<UserEntity?> GetUserAsync(string id);
    Task<string?> UpdateUserAsync(string id, string firstName, string lastName);
    Task<bool> DeleteUserAsync(string id);
}