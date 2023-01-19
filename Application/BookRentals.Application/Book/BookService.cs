using AutoMapper;
using BookRentals.Application.Abstractions;
using BookRentals.Common.Services;
using BookRentals.Common.Services.Helper;
using BookRentals.Domain;
using Microsoft.Extensions.Configuration;

namespace BookRentals.Application
{
    public class BookService : IBookService
    {
        private readonly IDataManager dataManager;
        private readonly IRepository<Book> bookRepository;
        private readonly IConfiguration configuration;
        private readonly IServiceResponseHelper serviceResponseHelper;
        private readonly IMapper mapper;

        public BookService(
            IDataManager dataManager,
            IRepository<Book> bookRepository,
            IConfiguration configuration,
            IServiceResponseHelper serviceResponseHelper,
            IMapper mapper)
        {
            this.dataManager = dataManager;
            this.bookRepository = bookRepository;
            this.configuration = configuration;
            this.serviceResponseHelper = serviceResponseHelper;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<PagedResultDto<BookDto>>> SearchAsync(BookDataTableRequest request)
        {
            var records = await this.bookRepository
                .GetPagedListAsync(
                    predicate: p =>
                        (string.IsNullOrWhiteSpace(request.Name)
                            ? true
                            : p.Name.Contains(request.Name))
                        && (string.IsNullOrWhiteSpace(request.Author)
                            ? true
                            : p.Author.Contains(request.Author))
                        && (request.Isbn == null || request.Isbn <= 0
                            ? true
                            : p.Isbn == request.Isbn),
                    orderBy: null,
                    include: null,
                    pageIndex: request.PageNumber,
                    pageSize: request.PageSize,
                    indexFrom: 1)
                .ConfigureAwait(false);

            var items = this.mapper.Map<List<BookDto>>(records.Items);

            var result = new PagedResultDto<BookDto>
            {
                PagedList = items,
                RowCount = records.TotalCount,
                PageCount = records.TotalPages,
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                HasNextPage = request.PageNumber < records.TotalPages ? true : false,
                HasPreviousPage = request.PageNumber > 1 ? true : false,
            };

            return this.serviceResponseHelper.SetSuccess(result);
        }
    }
}
