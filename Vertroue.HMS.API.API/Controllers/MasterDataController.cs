using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.MasterData.Queries.GetMasterData;

namespace Vertroue.HMS.API.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MasterDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("states")]
        public async Task<IActionResult> GetStates()
        {
            var result = await _mediator.Send(new FetchStatesQuery());
            return Ok(result);
        }

        [HttpGet("cities/{stateId}")]
        public async Task<IActionResult> GetCities(int stateId)
        {
            var result = await _mediator.Send(new FetchCitiesQuery(stateId));
            return Ok(result);
        }

        [HttpGet("zones")]
        public async Task<IActionResult> GetZones()
        {
            var result = await _mediator.Send(new FetchZonesQuery());
            return Ok(result);
        }
    }
}
