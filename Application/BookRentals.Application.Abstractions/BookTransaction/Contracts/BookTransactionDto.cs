namespace BookRentals.Application.Abstractions
{
    public class BookTransactionDto : DtoHasBaseId<Guid>
    {
        public BookDto Book { get; set; }

        public MemberDto Member { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
