using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBookingConsoleProject.Domain.Model.Entity;

namespace HotelBookingConsoleProject.Infrastructure.EntityFramework.Configurations;
public class HotelTypeConfiguration : IEntityTypeConfiguration<HotelType>
{
    public void Configure(EntityTypeBuilder<HotelType> builder)
    {
        builder.HasIndex(ht => ht.Name).IsUnique();
        builder.Property(ht => ht.Name).HasMaxLength(100).IsRequired();

        builder.HasData(
            new HotelType { Id = 1, Name = "Luxury" },
            new HotelType { Id = 2, Name = "Economy" },
            new HotelType { Id = 3, Name = "Boutique" },
            new HotelType { Id = 4, Name = "Resort" },
            new HotelType { Id = 5, Name = "Hostel" }
        );
    }
}
