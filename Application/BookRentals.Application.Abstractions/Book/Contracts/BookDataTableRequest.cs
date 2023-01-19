namespace BookRentals.Application.Abstractions
{
    public class BookDataTableRequest : PagedRequest
    {
        public string? Name { get; set; }

        public string? Author { get; set; }

        public double? Isbn { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
