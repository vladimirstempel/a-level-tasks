using ConsoleEFApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleEFApp.Data.EntityConfigurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Age).IsRequired();
        builder.Property(p => p.ImageUrl).IsRequired();
        builder.Property(p => p.Description);

        builder.HasOne(h => h.Category)
            .WithOne()
            .HasForeignKey<Category>(c => c.Id);
        
        builder.HasOne(h => h.Breed)
            .WithOne()
            .HasForeignKey<Breed>(b => b.Id);
        
        builder.HasOne(h => h.Location)
            .WithOne()
            .HasForeignKey<Location>(l => l.Id);
    }
}