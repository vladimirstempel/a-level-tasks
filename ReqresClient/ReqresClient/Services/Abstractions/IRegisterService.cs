using System.Threading.Tasks;
using ReqresClient.Dtos.Responses;

namespace ReqresClient.Services.Abstractions;

public interface IRegisterService
{
    Task<RegisterResponse> Register(string email, string password);
    Task<ErrorResponse> RegisterFailed(string email);
    Task<LoginResponse> Login(string email, string password);
    Task<ErrorResponse> LoginFailed(string email);
}