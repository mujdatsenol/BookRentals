using BookRentals.Application;
using BookRentals.Application.Abstractions;
using BookRentals.Common.Services.Helper;
using BookRentals.Infrastructure.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace BookRentals.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IBookTransactionService, BookTransactionService>();
            services.AddTransient<IServiceResponseHelper, ServiceResponseHelper>();
        }

        public static void RegisterMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
        }
    }
}
