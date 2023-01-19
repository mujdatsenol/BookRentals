using BookRentals.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookRentals.Persistence
{
    // Add Migrations
    // dotnet ef migrations add InitialDatabase --output-dir Contexts\Main\Migrations --context BookRentals.Persistence.MainDbContext --project ..\..\Infrastructure\BookRentals.Persistence\BookRentals.Persistence.csproj --startup-project ..\..\Presentation\BookRentals.WebAPI\BookRentals.WebAPI.csproj

    // Update Databse
    // dotnet ef database update --context BookRentals.Persistence.MainDbContext --project ..\..\Infrastructure\BookRentals.Persistence\BookRentals.Persistence.csproj --startup-project ..\..\Presentation\BookRentals.WebAPI\BookRentals.WebAPI.csproj

    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<BookTransaction> BookTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // NOTE: CLI ile migration üretirken sorun yaşadım. Geçici bir çözüm olarak ekledim.
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Database=BookRentals;Integrated Security=true;TrustServerCertificate=Yes";
                string migrationsAssembly = "BookRentals.Persistence";

                optionsBuilder.UseSqlServer(
                    connectionString,
                    opt => opt.MigrationsAssembly(migrationsAssembly));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>(BookMappings.OnModelCreating);
            builder.Entity<Member>(MemberMappings.OnModelCreating);
            builder.Entity<BookTransaction>(BookTransactionMappings.OnModelCreating);
        }
    }
}
