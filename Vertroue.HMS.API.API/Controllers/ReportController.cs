using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Reports.Queries;

namespace Vertroue.HMS.API.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCorporatePendingCaseReport")]
        public async Task<IActionResult> GetCorporatePendingCaseReport([FromQuery] int corporateId, [FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
        {
            var query = new GetCorporateCasePendingReportQuery
            {
                CorporateId = corporateId,
                UserId = userId,
                UserType = userType,
                UserRole = userRole
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
