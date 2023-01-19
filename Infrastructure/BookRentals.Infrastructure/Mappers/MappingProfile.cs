using AutoMapper;
using BookRentals.Application.Abstractions;
using BookRentals.Domain;

namespace BookRentals.Infrastructure.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            this.DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            this.CreateMap<Book, BookDto>().ReverseMap().DisableCtorValidation();
            this.CreateMap<Member, MemberDto>().ReverseMap().DisableCtorValidation();
            this.CreateMap<BookTransaction, BookTransactionDto>().ReverseMap().DisableCtorValidation();
            this.CreateMap<BookTransaction, BookTransactionResponse>()
                .ForMember(d => d.BookName, o => o.MapFrom(m => m.Book.Name))
                .ForMember(d => d.Author, o => o.MapFrom(m => m.Book.Author))
                .ForMember(d => d.MemberFirstName, o => o.MapFrom(m => m.Member.FirstName))
                .ForMember(d => d.MemberLastName, o => o.MapFrom(m => m.Member.LastName))
                .DisableCtorValidation();
        }
    }
}
