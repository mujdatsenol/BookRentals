using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookRentals.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookRentals.Persistence
{
    public static class MemberMappings
    {
        public static void OnModelCreating(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(pa => pa.BookTransactions)
                .WithOne(p => p.Member)
                .OnDelete(DeleteBehavior.Cascade);

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<Member> builder)
        {
            var members = MemberSeed.Members();
            builder.HasData(members);
        }
    }
}
