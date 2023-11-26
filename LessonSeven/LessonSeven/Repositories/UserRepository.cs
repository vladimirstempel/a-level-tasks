using LessonSeven.Entities;
using LessonSeven.Models;
using LessonSeven.Repositories.Abstractions;

namespace LessonSeven.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<UserEntity> _userEntities = new ();
    
    public string AddUser(User user)
    {
        var userEntity = new UserEntity
        {
            Name = user.Name,
            Email = user.Email
        };
        
        _userEntities.Add(userEntity);

        return userEntity.Id.ToString();
    }

    public UserEntity GetUser(string id)
    {
        return _userEntities.Where(user => user.Id.ToString() == id);
    }
}