using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Add;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.AddInsurerRates;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Modify;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurerRates.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.AddCorporateUser;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.ModifyCorporateUser;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Queries;
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
    public async Task<IActionResult> GetCorporateList([FromQuery] int parentCorporateId, [FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
    {
        var query = new FetchCorporateListQuery(parentCorporateId, userId, userType, userRole);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("corporateUsers")]
    public async Task<IActionResult> GetCorporateUsers([FromQuery] FetchCorporateUsersQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("corporateUsers/add")]
    public async Task<IActionResult> AddUser([FromBody] AddCorporateUserCommand command) =>
        Ok(await _mediator.Send(command));

    [HttpPost("corporateUsers/modify")]
    public async Task<IActionResult> ModifyUser([FromBody] ModifyCorporateUserCommand command) =>
        Ok(await _mediator.Send(command));

    [HttpPost("corporateUsers/deactivate")]
    public async Task<IActionResult> DeactivateUser([FromBody] DeactivateCorporateUserCommand command) =>
        Ok(await _mediator.Send(command));

    [HttpGet("{corporateInsurers}")]
    public async Task<IActionResult> GetCorporateInsurers(
       int corporateId,
       [FromQuery] int userId,
       [FromQuery] string userType,
       [FromQuery] string userRole)
    {
        var result = await _mediator.Send(new FetchCorporateInsurerQuery(corporateId, userId, userType, userRole));
        return Ok(result);
    }

    [HttpGet("rates")]
    public async Task<IActionResult> GetCorporateInsurerRates(
    [FromQuery] int corporateInsurerId,
    [FromQuery] int corporateId,
    [FromQuery] int userId,
    [FromQuery] string userType,
    [FromQuery] string userRole)
    {
        var result = await _mediator.Send(new FetchCorporateInsurerRatesQuery(
            corporateInsurerId,
            corporateId,
            userId,
            userType,
            userRole
        ));

        return Ok(result);
    }

    [HttpPost("corporateInsurerDeactivate")]
    public async Task<IActionResult> Deactivate([FromBody] DeactivateCorporateInsurerCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("corporateInsurerAdd")]
    public async Task<IActionResult> Add([FromBody] AddCorporateInsurerCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("corporateInsurerUpdate")]
    public async Task<IActionResult> Update([FromBody] ModifyCorporateInsurerCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("corporateInsurerAddRates")]
    public async Task<IActionResult> AddRates([FromBody] AddCorporateInsurerRateCommand command)
        => Ok(await _mediator.Send(command));

    [HttpGet("corporate-mou")]
    public async Task<IActionResult> FetchMOU([FromQuery] int corporateInsurerId,
    [FromQuery] int corporateId,
    [FromQuery] int userId,
    [FromQuery] string userType,
    [FromQuery] string userRole)
    {
        var result = await _mediator.Send(new FetchCorporateMOUQuery(
            corporateId,
            userId,
            userType,
            userRole));
        return Ok(result);
    }

}