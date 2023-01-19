namespace BookRentals.Application.Abstractions
{
    public class BookTransactionResponse : DtoHasBaseId<Guid>
    {
        public string BookName { get; set; }

        public string Author { get; set; }

        public string MemberFirstName { get; set; }

        public string MemberLastName { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
