using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookRentals.Domain;

namespace BookRentals.Persistence
{
    public static class BookTransactionMappings
    {
        public static void OnModelCreating(EntityTypeBuilder<BookTransaction> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(pa => pa.Book)
                .WithMany(p => p.BookTransactions)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pa => pa.Member)
                .WithMany(p => p.BookTransactions)
                .OnDelete(DeleteBehavior.Cascade);

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<BookTransaction> builder)
        {
            var bookTransaction = BookTransactionSeed.BookTransaction();
            builder.HasData(bookTransaction);
        }
    }
}
