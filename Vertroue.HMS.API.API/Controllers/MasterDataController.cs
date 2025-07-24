using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.Cities.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.Cities.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.Cities.Commands.Modify;
using Vertroue.HMS.API.Application.Features.MasterData.Cities.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Commands;
using Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Queries;
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


        [HttpPost("addCorporateType")]
        public async Task<IActionResult> AddCorporateType(AddCorporateTypeMasterCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut("updateCorporateType")]
        public async Task<IActionResult> UpdateCorporateType(UpdateCorporateTypeMasterCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPatch("deactivateCorporateType")]
        public async Task<IActionResult> DeactivateCorporateType(DeactivateCorporateTypeMasterCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet("allCorporateType")]
        public async Task<IActionResult> GetAllCorporateType()
            => Ok(await _mediator.Send(new FetchCorporateTypeMasterQuery()));

        [HttpPost("addAdmissionType")]
        public async Task<IActionResult> AddAdmissionType(AddAdmissionTypeCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut("updateAdmissionType")]
        public async Task<IActionResult> UpdateAdmissionType(UpdateAdmissionTypeCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut("deactivateAdmissionType")]
        public async Task<IActionResult> DeactivateAdmissionType(DeactivateAdmissionTypeCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet("allAdmissionType")]
        public async Task<IActionResult> GetAllAdmissionType()
            => Ok(await _mediator.Send(new GetAllAdmissionTypesQuery()));

        [HttpPost("addCities")]
        public async Task<IActionResult> AddCities(AddCityCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut("updateCities")]
        public async Task<IActionResult> UpdateCities(ModifyCityCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut("deactivateCities")]
        public async Task<IActionResult> DeactivateCities(DeactivateCityCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet("allCities")]
        public async Task<IActionResult> GetAllCities()
            => Ok(await _mediator.Send(new FetchCityMasterQuery()));

        [HttpPost("addCorporatePlan")]
        public async Task<IActionResult> AddCorporatePlan(AddCorporatePlanCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut("updateCorporatePlan")]
        public async Task<IActionResult> UpdateCorporatePlan(UpdateCorporatePlanCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut("deactivateCorporatePlan")]
        public async Task<IActionResult> DeactivateCorporatePlan(DeactivateCorporatePlanCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet("allCorporatePlan")]
        public async Task<IActionResult> GetAllCorporatePlan()
            => Ok(await _mediator.Send(new GetAllCorporatePlansQuery()));

        [HttpPost("addCorporateServiceRenewal")]
        public async Task<IActionResult> AddCorporateServiceRenewal(AddServiceRenewalCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut("updateCorporateServiceRenewal")]
        public async Task<IActionResult> UpdateCorporateServiceRenewal(UpdateServiceRenewalCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut("deactivateCorporateServiceRenewal")]
        public async Task<IActionResult> DeactivateCorporateServiceRenewal(DeactivateServiceRenewalCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet("allCorporateServiceRenewal")]
        public async Task<IActionResult> GetAllCorporateServiceRenewal()
            => Ok(await _mediator.Send(new GetAllServiceRenewalsQuery()));

        [HttpPost("addDocumentType")]
        public async Task<IActionResult> Add(AddDocumentTypeCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpPut("updateDocumentType")]
        public async Task<IActionResult> Update(UpdateDocumentTypeCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpPatch("deactivateDocumentType")]
        public async Task<IActionResult> Deactivate(DeactivateDocumentTypeCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpGet("allDocumentType")]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetAllDocumentTypesQuery()));

        [HttpPost("addGender")]
        public async Task<IActionResult> Add(AddGenderCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpPut("updateGender")]
        public async Task<IActionResult> Update(UpdateGenderCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpPatch("deactivateGender")]
        public async Task<IActionResult> Deactivate(DeactivateGenderCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpGet("allGender")]
        public async Task<IActionResult> GetAllGender() => Ok(await _mediator.Send(new GetAllGendersQuery()));

        [HttpPost("addIdentificationType")]
        public async Task<IActionResult> AddIdentificationType(AddIdentificationTypeCommand command) =>
        Ok(await _mediator.Send(command));

        [HttpPut("updateIdentificationType")]
        public async Task<IActionResult> UpdateIdentificationType(UpdateIdentificationTypeCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch("deactivateIdentificationType")]
        public async Task<IActionResult> DeactivateIdentificationType(DeactivateIdentificationTypeCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpGet("allIdentificationType")]
        public async Task<IActionResult> GetAllIdentificationType() =>
            Ok(await _mediator.Send(new GetAllIdentificationTypesQuery()));

    }
}
