using System;
using LessonSeven.Repositories;
using LessonSeven.Services;

namespace LessonSeven
{
    public static class Program
    {
        public static void Main()
        {
            // ...
            var result = new UserService(new UserRepository());

            result.AddUser("Test", "User");
        }
    }
}