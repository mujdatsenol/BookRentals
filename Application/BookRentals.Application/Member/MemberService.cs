using AutoMapper;
using BookRentals.Application.Abstractions;
using BookRentals.Common.Services;
using BookRentals.Common.Services.Helper;
using BookRentals.Domain;
using Microsoft.Extensions.Configuration;

namespace BookRentals.Application
{
    public class MemberService : IMemberService
    {
        private readonly IDataManager dataManager;
        private readonly IRepository<Member> memberRepository;
        private readonly IConfiguration configuration;
        private readonly IServiceResponseHelper serviceResponseHelper;
        private readonly IMapper mapper;

        public MemberService(
            IDataManager dataManager,
            IRepository<Member> memberRepository,
            IConfiguration configuration,
            IServiceResponseHelper serviceResponseHelper,
            IMapper mapper)
        {
            this.dataManager = dataManager;
            this.memberRepository = memberRepository;
            this.configuration = configuration;
            this.serviceResponseHelper = serviceResponseHelper;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<MemberDto>>> GetMembers()
        {
            var result = await this.memberRepository.GetListAsync(orderBy: o => o.OrderBy(o => o.IdentityNumber)).ConfigureAwait(false);

            var dtoResult = this.mapper.Map<List<MemberDto>>(result);

            return this.serviceResponseHelper.SetSuccess(dtoResult);
        }
    }
}
