using LessonSeven.Entities;
using LessonSeven.Models;

namespace LessonSeven.Repositories.Abstractions;

public interface IUserRepository
{
    string AddUser(User user);

    UserEntity GetUser(string id);
}