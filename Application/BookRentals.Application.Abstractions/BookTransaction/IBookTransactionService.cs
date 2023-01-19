using BookRentals.Common.Services;

namespace BookRentals.Application.Abstractions
{
    public interface IBookTransactionService : IApplicationService
    {
        Task<ServiceResponse<List<BookTransactionResponse>>> GetTransactions();

        Task<ServiceResponse> RentBookAsync(RentBookRequest request);
    }
}
