#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace BookRentals.Domain
{
    public class Book : IEntity, IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public double Isbn { get; set; }

        public bool Rented { get; set; }

        public virtual ICollection<BookTransaction> BookTransactions { get; set; }
    }
}
