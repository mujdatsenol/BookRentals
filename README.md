# Getting Started with Database Migration

Add Migrations

### `dotnet ef migrations add InitialDatabase --output-dir Contexts\Main\Migrations --context BookRentals.Persistence.MainDbContext --project ..\..\Infrastructure\BookRentals.Persistence\BookRentals.Persistence.csproj --startup-project ..\..\Presentation\BookRentals.WebAPI\BookRentals.WebAPI.csproj`

Update Databse

### `dotnet ef database update --context BookRentals.Persistence.MainDbContext --project ..\..\Infrastructure\BookRentals.Persistence\BookRentals.Persistence.csproj --startup-project ..\..\Presentation\BookRentals.WebAPI\BookRentals.WebAPI.csproj`
