using BookRentals.Common;
using BookRentals.Domain;

namespace BookRentals.Persistence
{
    public static class BookTransactionSeed
    {
        public static List<BookTransaction> BookTransaction()
        {
            var workingDate = new WorkingDate();
            var books = BookSeed.Books().Where(w => w.Rented == true).ToList();
            var members = MemberSeed.Members();

            return new List<BookTransaction>()
            {
                new BookTransaction
                {
                    Id = Guid.NewGuid(),
                    BookId = books[0].Id,
                    MemberId = members[0].Id,
                    RentDate = DateTime.Now.AddDays(-35),
                    ReturnDate = workingDate.GetNextWorkingDay(DateTime.Now.AddDays(-2))
                },
                new BookTransaction
                {
                    Id = Guid.NewGuid(),
                    BookId = books[1].Id,
                    MemberId = members[1].Id,
                    RentDate = DateTime.Now.AddDays(6),
                    ReturnDate = workingDate.GetNextWorkingDay(DateTime.Now.AddDays(-5))
                },
                new BookTransaction
                {
                    Id = Guid.NewGuid(),
                    BookId = books[2].Id,
                    MemberId = members[2].Id,
                    RentDate = DateTime.Now.AddDays(7),
                    ReturnDate = workingDate.GetNextWorkingDay(DateTime.Now.AddDays(30))
                },
                new BookTransaction
                {
                    Id = Guid.NewGuid(),
                    BookId = books[3].Id,
                    MemberId = members[3].Id,
                    RentDate = DateTime.Now.AddDays(8),
                    ReturnDate = workingDate.GetNextWorkingDay(DateTime.Now.AddDays(30))
                },
                new BookTransaction
                {
                    Id = Guid.NewGuid(),
                    BookId = books[4].Id,
                    MemberId = members[4].Id,
                    RentDate = DateTime.Now.AddDays(9),
                    ReturnDate = workingDate.GetNextWorkingDay(DateTime.Now.AddDays(30))
                }
            };
        }
    }
}
