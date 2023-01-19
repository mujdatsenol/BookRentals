using AutoMapper;
using BookRentals.Application.Abstractions;
using BookRentals.Common;
using BookRentals.Common.Services;
using BookRentals.Common.Services.Helper;
using BookRentals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace BookRentals.Application
{
    public class BookTransactionService : IBookTransactionService
    {
        private readonly IDataManager dataManager;
        private readonly IRepository<BookTransaction> bookTransactionRepository;
        private readonly IRepository<Book> bookRepository;
        private readonly IRepository<Member> memberRepository;
        private readonly IConfiguration configuration;
        private readonly IServiceResponseHelper serviceResponseHelper;
        private readonly IMapper mapper;

        public BookTransactionService(
            IDataManager dataManager,
            IRepository<BookTransaction> bookTransactionRepository,
            IRepository<Book> bookRepository,
            IRepository<Member> memberRepository,
            IConfiguration configuration,
            IServiceResponseHelper serviceResponseHelper,
            IMapper mapper)
        {
            this.dataManager = dataManager;
            this.bookTransactionRepository = bookTransactionRepository;
            this.bookRepository = bookRepository;
            this.memberRepository = memberRepository;
            this.configuration = configuration;
            this.serviceResponseHelper = serviceResponseHelper;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<BookTransactionResponse>>> GetTransactions()
        {
            var result = await this.bookTransactionRepository.GetListAsync(
                predicate: p => p.Book.Rented,
                include: i => i.Include(i => i.Book).Include(i => i.Member),
                orderBy: o => o.OrderBy(o => o.ReturnDate)).ConfigureAwait(false);

            var dtoResult = this.mapper.Map<List<BookTransactionResponse>>(result);

            return this.serviceResponseHelper.SetSuccess(dtoResult);
        }

        public async Task<ServiceResponse> RentBookAsync(RentBookRequest request)
        {
            var book = await this.bookRepository
                .GetFirstOrDefaultAsync(g => g.Id == request.BookId).ConfigureAwait(false);
            if (book == null)
            {
                return this.serviceResponseHelper.SetError(
                    "Kiralanacak bir kitap bulanamadı!",
                    (int)HttpStatusCode.NotFound);
            }
            else if (book.Rented)
            {
                return this.serviceResponseHelper.SetError(
                    "Kitap başka bir üye tarafından kiralandı!",
                    (int)HttpStatusCode.BadRequest);
            }

            var member = await this.memberRepository
                .GetFirstOrDefaultAsync(g => g.IdentityNumber == request.IdentityNumber).ConfigureAwait(false);
            if (member == null)
            {
                return this.serviceResponseHelper.SetError(
                    "Girdiğiniz bilgilere uygun bir üye bulunamadı!",
                    (int)HttpStatusCode.BadRequest);
            }

            var transaction = new BookTransaction()
            {
                BookId = book.Id,
                MemberId = member.Id,
                RentDate = DateTime.Now,
                ReturnDate = request.ReturnDate ?? DateTime.Now.AddDays(30), // İade tarihi belirtilmemiş ise 30 gün sonrası olacak şekil de set ediliyor.
            };

            book.Rented = true;

            // Belirtilen iade tarihi resmi tatil günlerine geldiği sürece bir sonra ki çalışma gününe erteler.
            transaction.ReturnDate = new WorkingDate().GetNextWorkingDay(transaction.ReturnDate);

            await this.bookTransactionRepository.AddAsync(transaction).ConfigureAwait(false);
            await this.bookRepository.UpdateAsync(book).ConfigureAwait(false);

            return this.serviceResponseHelper.SetSuccess();
        }
    }
}
