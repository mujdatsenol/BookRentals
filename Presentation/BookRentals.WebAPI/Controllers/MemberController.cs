using BookRentals.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookRentals.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : BaseController
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.memberService.GetMembers().ConfigureAwait(false);

            return Ok(result);
        }
    }
}
