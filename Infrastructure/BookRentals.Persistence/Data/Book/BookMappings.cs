using BookRentals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRentals.Persistence
{
    public static class BookMappings
    {
        public static void OnModelCreating(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(pa => pa.BookTransactions)
                .WithOne(p => p.Book)
                .OnDelete(DeleteBehavior.Cascade);

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<Book> builder)
        {
            var books = BookSeed.Books();
            builder.HasData(books);
        }
    }
}
