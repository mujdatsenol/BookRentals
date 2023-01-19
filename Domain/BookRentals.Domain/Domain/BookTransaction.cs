#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace BookRentals.Domain
{
    public class BookTransaction : IEntity, IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        public Guid MemberId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Member Member { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
