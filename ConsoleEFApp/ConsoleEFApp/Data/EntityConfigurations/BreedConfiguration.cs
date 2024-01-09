using ConsoleEFApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleEFApp.Data.EntityConfigurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(p => p.BreedName).IsRequired();
        
        builder.HasOne(h => h.Category)
            .WithOne()
            .HasForeignKey<Category>(c => c.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}