using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PetEntity> Pets { get; set; } = null!;
    public DbSet<CategoryEntity> Categories { get; set; } = null!;
    public DbSet<BreedEntity> Breeds { get; set; } = null!;
    public DbSet<LocationEntity> Locations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BreedConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.UseHiLo();
    }
}