using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBookingConsoleProject.Domain.Model.Entity;

namespace HotelBookingConsoleProject.Infrastructure.EntityFramework.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.Property(h => h.Name).HasMaxLength(100);

        builder.HasMany(h => h.Rooms)
               .WithOne(r => r.Hotel)
               .HasForeignKey(r => r.HotelId)
               .IsRequired();

        builder.HasOne(h => h.HotelType)
               .WithMany()
               .HasForeignKey(h => h.HotelTypeId)
               .IsRequired();

        builder.HasData(
            new Hotel { Id = 1, Name = "Hotel Lux", HotelTypeId = 1 },
            new Hotel { Id = 2, Name = "Economy Stay", HotelTypeId = 2 },
            new Hotel { Id = 3, Name = "Boutique Paradise", HotelTypeId = 3 },
            new Hotel { Id = 4, Name = "Resort Haven", HotelTypeId = 4 },
            new Hotel { Id = 5, Name = "Traveler's Hostel", HotelTypeId = 5 }
        );
    }
}