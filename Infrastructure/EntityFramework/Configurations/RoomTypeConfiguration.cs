using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBookingConsoleProject.Domain.Model.Entity;

namespace HotelBookingConsoleProject.Infrastructure.EntityFramework.Configurations;
public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.HasIndex(rt => rt.Name).IsUnique();
        builder.Property(rt => rt.Name).HasMaxLength(100).IsRequired();

        builder.HasData(
            new RoomType { Id = 1, Name = "Single" },
            new RoomType { Id = 2, Name = "Double" },
            new RoomType { Id = 3, Name = "Suite" },
            new RoomType { Id = 4, Name = "Twin" },
            new RoomType { Id = 5, Name = "King" }
        );
    }
}
