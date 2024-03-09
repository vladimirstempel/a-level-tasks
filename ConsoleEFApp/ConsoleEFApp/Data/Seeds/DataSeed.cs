using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;
using ConsoleEFApp.Repositories.Abstractions;
using ConsoleEFApp.Services;
using Microsoft.Extensions.Logging;

namespace ConsoleEFApp.Data.Seeds;

public class DataSeed
{
    private readonly IPetRepository _petRepository;
    private readonly IBreedRepository _breedRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly ILogger<DataSeed> _logger;

    public DataSeed(
        IPetRepository petRepository,
        IBreedRepository breedRepository,
        ICategoryRepository categoryRepository,
        ILocationRepository locationRepository,
        ILogger<DataSeed> logger
        )
    {
        _petRepository = petRepository;
        _breedRepository = breedRepository;
        _categoryRepository = categoryRepository;
        _locationRepository = locationRepository;
        _logger = logger;
    }

    public async Task Init()
    {
        await CreateLocations();
        await CreateCategories();
        await CreateBreeds();
        await CreatePets();
    }
    
    private async Task CreateLocations() {
        var locations = new List<Location>
        {
            new()
            {
                LocationName = "Ukraine"
            },
            new()
            {
                LocationName = "United States"
            },
            new()
            {
                LocationName = "Canada"
            },
            new()
            {
                LocationName = "United Kingdom"
            }
        };

        var result = 0;

        foreach (var location in locations)
        {
            await _locationRepository.Create(location);
            result++;
        }
        
        _logger.LogInformation("Locations Created: {0}", result);
    }

    private async Task CreateCategories()
    {
        var categories = new List<Category>
        {
            new()
            {
                CategoryName = "Small-sized"
            },
            new()
            {
                CategoryName = "Medium-sized"
            },
            new()
            {
                CategoryName = "Large-sized"
            }
        };

        var result = 0;

        foreach (var category in categories)
        {
            await _categoryRepository.Create(category);
            result++;
        }
        
        _logger.LogInformation("Categories Created: {0}", result);
    }

    private async Task CreateBreeds()
    {
        var categories = await _categoryRepository.GetAll();
        
        var breeds = new List<Breed>
        {
            new()
            {
                BreedName = "Beagle",
                Category = GetCategoryByName(categories, "Small-sized")
            },
            new()
            {
                BreedName = "Labrador Retriever",
                Category = GetCategoryByName(categories, "Large-sized")
            },
            new()
            {
                BreedName = "Border Collie",
                Category = GetCategoryByName(categories, "Medium-sized")
            },
            new()
            {
                BreedName = "Ukrainian Shepherd",
                Category = GetCategoryByName(categories, "Large-sized")
            },
            new()
            {
                BreedName = "Ukrainian Hound",
                Category = GetCategoryByName(categories, "Medium-sized")
            }
        };

        var result = 0;

        foreach (var breed in breeds)
        {
            await _breedRepository.Create(breed);
            result++;
        }
        
        _logger.LogInformation("Breeds Created: {0}", result);
    }

    private async Task CreatePets()
    {
        var locations = await _locationRepository.GetAll();
        var categories = await _categoryRepository.GetAll();
        var breeds = await _breedRepository.GetAll();
        
        var pets = new List<Pet>
        {
            new()
            {
                Name = "Bobik",
                Age = 4,
                Description = "Bobik is a playful and intelligent Ukrainian Shepherd with a fluffy white coat. She is known for her protective nature and is a loyal companion to her family.",
                ImageUrl = "https://s3.envato.com/files/450999756/2023_05_13-ovcharenkoph%20(11).jpg",
                Breed = GetBreedByName(breeds, "Ukrainian Shepherd"),
                Category = GetCategoryByName(categories, "Large-sized"),
                Location = GetLocationByName(locations, "Ukraine"),
            },
            new()
            {
                Name = "Linda",
                Age = 6,
                Description = "Linda is a friendly and adventurous Ukrainian Hound with a tricolor coat. He loves exploring the countryside and has a keen sense of smell.",
                ImageUrl = "https://s3.envato.com/files/450999756/2023_05_13-ovcharenkoph%20(11).jpg",
                Breed = GetBreedByName(breeds, "Ukrainian Hound"),
                Category = GetCategoryByName(categories, "Medium-sized"),
                Location = GetLocationByName(locations, "Ukraine"),
            },
            new()
            {
                Name = "Oliver",
                Age = 4,
                Description = "Oliver is an adventurous and friendly Golden Retriever with a golden coat. He loves outdoor activities and is a popular dog in the community.",
                ImageUrl = "https://www.zooplus.de/magazin/wp-content/uploads/2017/03/border-collie.jpeg",
                Breed = GetBreedByName(breeds, "Border Collie"),
                Category = GetCategoryByName(categories, "Medium-sized"),
                Location = GetLocationByName(locations, "United States"),
            },
            new()
            {
                Name = "Charlie",
                Age = 1,
                Description = "Charlie is a playful and social Beagle with a tricolor coat. He loves sniffing around during walks and is great with children.",
                ImageUrl = "https://www.zooroyal.de/magazin/wp-content/uploads/2017/01/beagle-hunderasse-760x560.jpg",
                Breed = GetBreedByName(breeds, "Beagle"),
                Category = GetCategoryByName(categories, "Small-sized"),
                Location = GetLocationByName(locations, "United Kingdom"),
            },
            new()
            {
                Name = "Max",
                Age = 3,
                Description = "Max is a friendly and energetic Labrador Retriever with a golden coat. He enjoys swimming and is known for his loving nature.",
                ImageUrl = "https://www.zooroyal.de/magazin/wp-content/uploads/2017/01/beagle-hunderasse-760x560.jpg",
                Breed = GetBreedByName(breeds, "Labrador Retriever"),
                Category = GetCategoryByName(categories, "Large-sized"),
                Location = GetLocationByName(locations, "Canada"),
            }
        };

        var result = 0;

        foreach (var pet in pets)
        {
            await _petRepository.Create(pet);
            result++;
        }
        
        _logger.LogInformation("Pets Created: {0}", result);
    }

    private Location GetLocationByName(List<LocationEntity> locations, string name)
    {
        return locations
            .Select(entity =>
            {
                var model = new Location();
                entity.ToModel(model);
                return model;
            })
            .FirstOrDefault(c => c.LocationName == name)!;
    }

    private Category GetCategoryByName(List<CategoryEntity> categories, string name)
    {
        return categories
            .Select(entity =>
            {
                var model = new Category();
                entity.ToModel(model);
                return model;
            })
            .FirstOrDefault(c => c.CategoryName == name)!;
    }

    private Breed GetBreedByName(List<BreedEntity> breeds, string name)
    {
        return breeds
            .Select(entity =>
            {
                var model = new Breed();
                entity.ToModel(model);
                return model;
            })
            .FirstOrDefault(entity => entity.BreedName == name)!;
    }
}