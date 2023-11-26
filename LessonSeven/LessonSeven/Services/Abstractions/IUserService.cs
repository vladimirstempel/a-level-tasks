﻿using LessonSeven.Models;

namespace LessonSeven.Services.Abstractions;

public interface IUserService
{
    string AddUser(string firstName, string lastName);
    
    User GetUser(string id);
}