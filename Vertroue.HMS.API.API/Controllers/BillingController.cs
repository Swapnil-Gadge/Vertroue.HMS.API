using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Billing.PaidCases.Queries.GetPaidCase;
using Vertroue.HMS.API.Application.Features.Billing.PendingCases.Queries.GetPendingPayments;

namespace Vertroue.HMS.API.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("pending-cases")]
        public async Task<IActionResult> GetPendingCases([FromQuery] int corporateId, [FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
        {
            var query = new GetPendingPaymentCasesQuery(corporateId, userId, userType, userRole);
            var result = await _mediator.Send(query);
            return Ok(result);
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
