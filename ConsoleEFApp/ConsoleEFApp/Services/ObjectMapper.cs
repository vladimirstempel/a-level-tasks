using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Data.Entities.Abstractions;
using ConsoleEFApp.Models;
using ConsoleEFApp.Models.Abstractions;

namespace ConsoleEFApp.Services;

public static class ObjectMapper
{
    public static TModel? ToModel<TModel>(this IEntity entity, TModel model)
        where TModel : class
    {
        if (model is Pet pet && entity is PetEntity petEntity)
        {

            pet.Id = petEntity.Id;
            pet.Name = petEntity.Name;
            pet.Age = petEntity.Age;
            pet.Description = petEntity.Description;
            pet.ImageUrl = petEntity.ImageUrl;
            pet.Breed = petEntity.Breed?.ToModel(new Breed());
            pet.Category = petEntity.Category?.ToModel(new Category());
            pet.Location = petEntity.Location?.ToModel(new Location());
            
            return pet as TModel;
        }
        if (model is Breed breed && entity is BreedEntity breedEntity)
        {
            breed.Id = breedEntity.Id;
            breed.BreedName = breedEntity.BreedName;
            
            return breed as TModel;
        }
        if (model is Category category && entity is CategoryEntity categoryEntity)
        {
            category.Id = categoryEntity.Id;
            category.CategoryName = categoryEntity.CategoryName;
            
            return category as TModel;
        }
        if (model is Location location && entity is LocationEntity locationEntity)
        {
            location.Id = locationEntity.Id;
            location.LocationName = locationEntity.LocationName;
            
            return location as TModel;
        }

        return null;
    }

    public static TEntity? ToEntity<TEntity>(this IModel model, TEntity entity)
        where TEntity : class
    {
        if (model is Pet pet && entity is PetEntity petEntity)
        {
            if (pet.Id != null)
            {
                petEntity.Id = pet.Id;
            }
            petEntity.Name = pet.Name;
            petEntity.Age = pet.Age;
            petEntity.Description = pet.Description;
            petEntity.ImageUrl = pet.ImageUrl;
            petEntity.BreedId = pet.Breed?.ToEntity(new BreedEntity())?.Id;
            petEntity.CategoryId = pet.Category?.ToEntity(new CategoryEntity())?.Id;
            petEntity.LocationId = pet.Location?.ToEntity(new LocationEntity())?.Id;
            
            return petEntity as TEntity;
        }
        if (model is Breed breed && entity is BreedEntity breedEntity)
        {
            if (breed.Id != null)
            {
                breedEntity.Id = breed.Id;
            }
            breedEntity.BreedName = breed.BreedName;
            
            return breedEntity as TEntity;
        }
        if (model is Category category && entity is CategoryEntity categoryEntity)
        {
            if (category.Id != null)
            {
                categoryEntity.Id = category.Id;
            }
            categoryEntity.CategoryName = category.CategoryName;
            
            return categoryEntity as TEntity;
        }
        if (model is Location location && entity is LocationEntity locationEntity)
        {
            if (location.Id != null)
            {
                locationEntity.Id = location.Id;
            }
            locationEntity.LocationName = location.LocationName;
            
            return locationEntity as TEntity;
        }

        return null;
    }
}