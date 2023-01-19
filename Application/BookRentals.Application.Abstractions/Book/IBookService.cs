using BookRentals.Common.Services;

namespace BookRentals.Application.Abstractions
{
    public interface IBookService : IApplicationService
    {
        Task<ServiceResponse<PagedResultDto<BookDto>>> SearchAsync(BookDataTableRequest request);
    }
}
