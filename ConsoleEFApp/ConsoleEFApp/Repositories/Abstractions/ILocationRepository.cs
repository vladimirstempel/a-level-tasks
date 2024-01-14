using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Models;

namespace ConsoleEFApp.Repositories.Abstractions;

public interface ILocationRepository : IBaseRepository<LocationEntity, Location>
{
}