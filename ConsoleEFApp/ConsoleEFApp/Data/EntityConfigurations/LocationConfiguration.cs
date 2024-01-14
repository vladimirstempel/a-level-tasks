using ConsoleEFApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleEFApp.Data.EntityConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.LocationName).IsRequired();
        
        builder.HasKey(h => h.Id);

        builder
            .HasMany<PetEntity>(h => h.Pets)
            .WithOne(w => w.Location)
            .HasForeignKey(h => h.LocationId);
    }
}