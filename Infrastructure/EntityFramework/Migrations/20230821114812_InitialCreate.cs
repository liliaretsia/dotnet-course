using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBookingConsoleProject.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HotelTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_HotelType_HotelTypeId",
                        column: x => x.HotelTypeId,
                        principalTable: "HotelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    RoomTypeId = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HotelType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Luxury" },
                    { 2, "Economy" },
                    { 3, "Boutique" },
                    { 4, "Resort" },
                    { 5, "Hostel" }
                });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "Double" },
                    { 3, "Suite" },
                    { 4, "Twin" },
                    { 5, "King" }
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "HotelTypeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Hotel Lux" },
                    { 2, 2, "Economy Stay" },
                    { 3, 3, "Boutique Paradise" },
                    { 4, 4, "Resort Haven" },
                    { 5, 5, "Traveler's Hostel" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Description", "HotelId", "Name", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, "Lux Single Room", 1, "", 1 },
                    { 2, "Economy Double Room", 2, "", 2 },
                    { 3, "Boutique Suite", 3, "", 3 },
                    { 4, "Resort Twin Room", 4, "", 4 },
                    { 5, "Hostel King Room", 5, "", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_HotelTypeId",
                table: "Hotel",
                column: "HotelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelType_Name",
                table: "HotelType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_Name",
                table: "RoomType",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "HotelType");
        }
    }
}
