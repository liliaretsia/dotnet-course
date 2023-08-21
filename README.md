**Create migration:**

`dotnet ef migrations add InitialCreate --context AppDbContext --output-dir Infrastructure.EntityFramework.Migrations --namespace HotelBooking.Infrastructure.EntityFramework.Migrations`

**To add a new hotel:**

`dotnet run add --name "HotelName" --type 1`, execute the command

**To fetch data from the database:**

`dotnet run fetch`, execute the command


