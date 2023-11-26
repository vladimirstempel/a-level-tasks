using LessonSeven.Models;
using LessonSeven.Repositories;
using LessonSeven.Repositories.Abstractions;
using LessonSeven.Services.Abstractions;

namespace LessonSeven.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public string AddUser(string firstName, string lastName)
    {
        var user = new User
        {
            Name = $"{firstName} {lastName}",
            Email = "blabla@gmail.com"
        };

        var userId = _userRepository.AddUser(user);

        return userId;
    }

    public User GetUser(string id)
    {
        throw new NotImplementedException();
    }
}