using BookRentals.Common.Services;

namespace BookRentals.Application.Abstractions
{
    public interface IMemberService : IApplicationService
    {
        Task<ServiceResponse<List<MemberDto>>> GetMembers();
    }
}
