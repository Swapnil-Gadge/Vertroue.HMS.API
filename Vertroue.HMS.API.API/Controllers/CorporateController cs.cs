using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.List.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Commands;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Queries;

[ApiController]
[Route("api/[controller]")]
public class CorporateController : ControllerBase
{
    private readonly IMediator _mediator;

    public CorporateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("parent")]
    public async Task<IActionResult> GetParentCorporate([FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
    {
        var query = new FetchParentCorporateQuery(userId, userType, userRole);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("parent")]
    public async Task<IActionResult> SaveParentCorporate([FromBody] SaveParentCorporateCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("details")]
    public async Task<IActionResult> GetCorporateDetails([FromQuery] int parentCorporateId, [FromQuery] int corporateId, [FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
    {
        var query = new FetchCorporateDetailsQuery(parentCorporateId, corporateId, userId, userType, userRole);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetCorporateList([FromQuery] int parentCorporateId,  [FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
    {
        var query = new FetchCorporateListQuery(parentCorporateId, userId, userType, userRole);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}