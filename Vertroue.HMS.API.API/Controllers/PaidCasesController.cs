using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.PaidCases.Queries.GetPaidCase;

namespace Vertroue.HMS.API.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaidCasesController : Controller
    {
        private readonly IMediator _mediator;

        public PaidCasesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{corporateId}")]
        public async Task<IActionResult> GetPaidCases(int corporateId, [FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
        {
            var query = new GetPaidCasesQuery(corporateId, userId, userType, userRole);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
