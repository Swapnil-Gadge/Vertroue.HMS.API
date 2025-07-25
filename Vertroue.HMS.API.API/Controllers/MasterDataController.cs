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
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.States.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.States.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.States.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.States.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Model;
using Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.UserRole.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.UserRole.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.UserRole.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.UserRole.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.UserType.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.UserType.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.UserType.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.UserType.Queries;
using Vertroue.HMS.API.Application.Features.MasterData.Zone.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.Zone.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.Zone.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.Zone.Queries;

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

        //[HttpGet("states")]
        //public async Task<IActionResult> GetStates()
        //{
        //    var result = await _mediator.Send(new FetchStatesQuery());
        //    return Ok(result);
        //}

        //[HttpGet("cities/{stateId}")]
        //public async Task<IActionResult> GetCities(int stateId)
        //{
        //    var result = await _mediator.Send(new FetchCitiesQuery(stateId));
        //    return Ok(result);
        //}

        //[HttpGet("zones")]
        //public async Task<IActionResult> GetZones()
        //{
        //    var result = await _mediator.Send(new FetchZonesQuery());
        //    return Ok(result);
        //}


        #region Corporate Type Endpoints
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
        #endregion

        #region Admission Type Endpoints
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
        #endregion

        #region City Endpoints
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
        #endregion

        #region Corporate Plan Endpoints
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
        #endregion

        #region Corporate Service Renewal Endpoints
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
        #endregion

        #region Document Type Endpoints
        [HttpPost("addDocumentType")]
        public async Task<IActionResult> Add(AddDocumentTypeCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpPut("updateDocumentType")]
        public async Task<IActionResult> Update(UpdateDocumentTypeCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpPatch("deactivateDocumentType")]
        public async Task<IActionResult> Deactivate(DeactivateDocumentTypeCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpGet("allDocumentType")]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetAllDocumentTypesQuery()));
        #endregion

        #region Gender Endpoints
        [HttpPost("addGender")]
        public async Task<IActionResult> Add(AddGenderCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpPut("updateGender")]
        public async Task<IActionResult> Update(UpdateGenderCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpPatch("deactivateGender")]
        public async Task<IActionResult> Deactivate(DeactivateGenderCommand cmd) => Ok(await _mediator.Send(cmd));

        [HttpGet("allGender")]
        public async Task<IActionResult> GetAllGender() => Ok(await _mediator.Send(new GetAllGendersQuery()));
        #endregion

        #region Identification Type Endpoints
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
        #endregion

        #region Insurer Endpoints
        [HttpPost("addInsurer")]
        public async Task<IActionResult> AddInsurer([FromBody] AddInsurerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("updateInsurer")]
        public async Task<IActionResult> UpdateInsurer([FromBody] UpdateInsurerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch("deactivateInsurer")]
        public async Task<IActionResult> DeactivateInsurer([FromBody] DeactivateInsurerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("allInsurer")]
        public async Task<IActionResult> GetAllInsurers()
        {
            var result = await _mediator.Send(new GetAllInsurersQuery());
            return Ok(result);
        }
        #endregion

        #region Relation Master Endpoints
        [HttpPost("addRelationMaster")]
        public async Task<IActionResult> Add(AddRelationMasterCommand command) =>
       Ok(await _mediator.Send(command));

        [HttpPut("updateRelationMaster")]
        public async Task<IActionResult> Update(UpdateRelationMasterCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete("deactivateRelationMaster")]
        public async Task<IActionResult> Deactivate(DeactivateRelationMasterCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpGet("allRelationMaster")]
        public async Task<IActionResult> Get() =>
            Ok(await _mediator.Send(new GetRelationMasterQuery()));
        #endregion

        #region State Endpoints
        [HttpPost("addStates")]
        public async Task<IActionResult> Add(AddStateCommand command)
        => Ok(await _mediator.Send(command));

        [HttpPut("updateStates")]
        public async Task<IActionResult> Update(UpdateStateCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPatch("deactivateStates")]
        public async Task<IActionResult> Deactivate(DeactivateStateCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet("allStates")]
        public async Task<IActionResult> GetAllStates()
            => Ok(await _mediator.Send(new GetAllStatesQuery()));
        #endregion

        #region Status Master Endpoints
        [HttpPost("addStatusMaster")]
        public async Task<IActionResult> Add([FromBody] AddStatusMasterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("updateStatusMaster")]
        public async Task<IActionResult> Update([FromBody] UpdateStatusMasterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("deactivateStatusMaster")]
        public async Task<IActionResult> Deactivate([FromBody] DeactivateStatusMasterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("allStatusMaster")]
        public async Task<IActionResult> GetAll([FromQuery] int userId)
        {
            var result = await _mediator.Send(new GetAllStatusMasterQuery { UserId = userId });
            return Ok(result);
        }
        #endregion

        #region Status Process Flow Endpoints
        [HttpPost("addStatusProcessFlow")]
        public async Task<IActionResult> Add(AddStatusProcessFlowCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("updateStatusProcessFlow")]
        public async Task<IActionResult> Update(UpdateStatusProcessFlowCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("deactivateStatusProcessFlow")]
        public async Task<IActionResult> Deactivate(DeactivateStatusProcessFlowCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("allStatusProcessFlow")]
        public async Task<ActionResult<List<StatusProcessFlowDto>>> GetAllStatusProcessFlowCommand()
        {
            return Ok(await _mediator.Send(new GetStatusProcessFlowQuery()));
        }
        #endregion

        #region User Role Endpoints
        [HttpPost("addUserRole")]
        public async Task<IActionResult> AddUserRole(AddUserRoleCommand command) => Ok(await _mediator.Send(command));

        [HttpPut("updateUserRole")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleCommand command) => Ok(await _mediator.Send(command));

        [HttpDelete("deactivateUserRole")]
        public async Task<IActionResult> DeactivateUserRole(DeactivateUserRoleCommand command) => Ok(await _mediator.Send(command));

        [HttpGet("allUserRole")]
        public async Task<IActionResult> GetAllUserRole() => Ok(await _mediator.Send(new GetUserRolesQuery()));
        #endregion

        #region User Type Endpoints
        [HttpPost("addUserType")]
        public async Task<IActionResult> AddUserType(AddUserTypeCommand command) =>
        Ok(await _mediator.Send(command));

        [HttpPut("updateUserType")]
        public async Task<IActionResult> UpdateUserType(UpdateUserTypeCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPut("deactivateUserType")]
        public async Task<IActionResult> DeactivateUserType(DeactivateUserTypeCommand command) =>
        Ok(await _mediator.Send(command));

        [HttpGet("allUserType")]
        public async Task<IActionResult> GetAllUserType() =>
            Ok(await _mediator.Send(new GetAllUserTypesQuery()));
        #endregion

        #region Zone Endpoints
        [HttpPut("updateZone")]
        public async Task<IActionResult> UpdateZone([FromBody] UpdateZoneCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("deactivateZone")]
        public async Task<IActionResult> DeactivateZone([FromBody] DeactivateZoneCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("addZone")]
        public async Task<IActionResult> AddZone([FromBody] AddZoneCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("allZones")]
        public async Task<IActionResult> GetAllZones()
        {
            var result = await _mediator.Send(new GetAllZonesQuery());
            return Ok(result);
        }
        #endregion
    }
}
