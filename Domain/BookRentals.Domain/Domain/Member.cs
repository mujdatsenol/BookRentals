#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace BookRentals.Domain
{
    public class Member : IEntity, IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string IdentityNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<BookTransaction> BookTransactions { get; set; }
    }
}
