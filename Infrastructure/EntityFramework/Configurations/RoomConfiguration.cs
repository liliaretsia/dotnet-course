using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBookingConsoleProject.Domain.Model.Entity;

namespace HotelBookingConsoleProject.Infrastructure.EntityFramework.Configurations;
public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(r => r.Description).HasMaxLength(500);

        builder.HasOne(r => r.RoomType)
               .WithMany()
               .HasForeignKey(r => r.RoomTypeId)
               .IsRequired();

        builder.HasData(
            new Room { Id = 1, Name = "Lux Single", Description = "Lux Single Room", HotelId = 1, RoomTypeId = 1 },
            new Room { Id = 2, Name = "Economy Double", Description = "Economy Double Room", HotelId = 2, RoomTypeId = 2 },
            new Room { Id = 3, Name = "Boutique Suite", Description = "Boutique Suite", HotelId = 3, RoomTypeId = 3 },
            new Room { Id = 4, Name = "Boutique Suite", Description = "Boutique Suite Room", HotelId = 4, RoomTypeId = 4 },
            new Room { Id = 5, Name = "Hostel King", Description = "Hostel King Room", HotelId = 5, RoomTypeId = 5 }
        );
    }
}
