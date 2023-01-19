namespace BookRentals.Application.Abstractions
{
    public class BookDto : DtoHasBaseId<Guid>
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public double Isbn { get; set; }

        public bool Rented { get; set; }

        public IList<BookTransactionDto> BookTransactions { get; set; }
    }
}
