using System;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<string> AddUserAsync(string firstName, string lastName)
    {
        var user = new UserEntity()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = firstName,
            LastName = lastName
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task<UserEntity?> GetUserAsync(string id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<string?> UpdateUserAsync(string id, string firstName, string lastName)
    {
        var userEntity = await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == id);

        if (userEntity == null)
        {
            return null;
        }

        userEntity.FirstName = firstName;
        userEntity.LastName = lastName;

        await _dbContext.SaveChangesAsync();

        return userEntity.Id;
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        var userEntity = await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == id);

        if (userEntity == null)
        {
            return false;
        }

        _dbContext.Remove(userEntity);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}