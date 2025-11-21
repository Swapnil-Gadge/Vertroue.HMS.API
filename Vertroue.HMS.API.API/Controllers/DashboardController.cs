using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Dashboards.Queries.GetProviderAdminDashboard;

namespace Vertroue.HMS.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("providerAdminDashboard")]
        public async Task<ActionResult<GetProviderAdminDashboardResponse>> GetProviderAdminDashboard([FromQuery] int? hospitalId)
        {
            var response = await _mediator.Send(new GetProviderAdminDashboardQuery
            {
                HospitalId = hospitalId
            });
            return Ok(response);
        }
    }
}
