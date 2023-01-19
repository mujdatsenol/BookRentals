namespace BookRentals.Application.Abstractions
{
    public class MemberDto : DtoHasBaseId<Guid>
    {
        public string IdentityNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<BookTransactionDto> BookTransactions { get; set; }
    }
}
