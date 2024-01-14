using ConsoleEFApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleEFApp.Data.EntityConfigurations;

public class BreedConfiguration : IEntityTypeConfiguration<BreedEntity>
{
    public void Configure(EntityTypeBuilder<BreedEntity> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.BreedName).IsRequired();
        
        builder.HasKey(h => h.Id);

        builder
            .HasMany<PetEntity>(h => h.Pets)
            .WithOne(w => w.Breed)
            .HasForeignKey(h => h.BreedId);
    }
}