using ConsoleEFApp.Data;
using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ConsoleEFApp.Services;

public class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(
        ICategoryRepository categoryRepository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<PetService> logger)
        : base(dbContextWrapper, logger)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> Create(Category model)
    {
        var id = await _categoryRepository.Create(model);

        return id;
    }

    public async Task<Category?> Get(int id)
    {
        var entity = await _categoryRepository.Get(id);

        if (entity == null)
        {
            return null;
        }

        var model = new Category();

        entity.ToModel(model);

        return model;
    }

    public async Task<List<Category>?> GetAll()
    {
        var entities = await _categoryRepository.GetAll();

        if (entities == null)
        {
            return null;
        }
        
        var models = entities
            .Select<CategoryEntity, Category>(entity =>
            {
                var model = new Category();
                entity.ToModel(model);
                return model;
            })
            .ToList();
        
        return models;
    }

    public async Task<int?> Update(int id, Category model)
    {
        return await _categoryRepository.Update(id, model);
    }

    public async Task<bool> Delete(int id)
    {
        return await _categoryRepository.Delete(id);
    }
}