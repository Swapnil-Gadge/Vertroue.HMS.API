using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Dashboards.Queries.GetProviderAdminDashboard;
using Vertroue.HMS.API.Application.Features.Users.Commands.Login;
using Vertroue.HMS.API.Application.Responses;

namespace Vertroue.HMS.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("providerAdminDashboard")]
        public async Task<ActionResult<GetProviderAdminDashboardResponse>> GetProviderAdminDashboard()
        {
            var response = await _mediator.Send(new GetProviderAdminDashboardQuery());
            return Ok(response);
        }
    }
}
