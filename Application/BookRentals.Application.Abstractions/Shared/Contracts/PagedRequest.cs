using System.ComponentModel.DataAnnotations;

namespace BookRentals.Application.Abstractions
{
    public class PagedRequest
    {
        [Range(1, int.MaxValue)]
        public int PageIndex { get; set; } = 1;

        [Range(1, int.MaxValue)]
        public int PageSize { get; set; } = 10;
    }
}
