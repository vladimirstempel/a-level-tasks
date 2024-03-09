using ConsoleEFApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleEFApp.Data.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.Property(h => h.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.CategoryName).IsRequired();
        
        builder.HasKey(h => h.Id);

        builder
            .HasMany<PetEntity>(h => h.Pets)
            .WithOne(w => w.Category)
            .HasForeignKey(h => h.CategoryId);

        builder
            .HasMany<BreedEntity>(h => h.Breeds)
            .WithOne(w => w.Category)
            .HasForeignKey(h => h.CategoryId);
    }
}