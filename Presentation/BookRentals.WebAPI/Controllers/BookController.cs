using AutoMapper;
using BookRentals.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookRentals.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IBookTransactionService bookTransactionService;

        public BookController(
            IBookService bookService,
            IBookTransactionService bookTransactionService)
        {
            this.bookService = bookService;
            this.bookTransactionService = bookTransactionService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]BookDataTableRequest request)
        {
            var result = await this.bookService.SearchAsync(request).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> Transactions()
        {
            var result = await this.bookTransactionService.GetTransactions().ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost("rent")]
        public async Task<IActionResult> Rent([FromBody] RentBookRequest request)
        {
            var result = await this.bookTransactionService.RentBookAsync(request).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
