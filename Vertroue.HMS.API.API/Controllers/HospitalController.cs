using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateContact;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateDoctorCommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateEmapnelledTPACommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateEmpanelledInsuranceCompany;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateHospital;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateMou;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateRenewal;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateUser;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableContact;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableDoctorCommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableEmpanelledInsuranceCompanyCommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableHospital;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableMou;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableRenewal;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableTpaCommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableUser;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateContact;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateDoctorCommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateEmapnelledTPACommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateEmpanelledInsuranceCompanyCommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateHospital;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateMou;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateRenewal;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateUser;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetContacts;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetDoctorsQuery;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetEmapnelledTpaQuery;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetEmpanelledInsuranceCompanyQuery;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospital;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospitalData;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospitals;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetMous;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetRenewals;
using Vertroue.HMS.API.Application.Features.Hospital.Queries.GetUsers;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HospitalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateHospital(CreateHospitalCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateHospital(UpdateHospitalCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("deactivate")]
        public async Task<ActionResult<bool>> DeactivateHospital([FromQuery] int hospitalId)
        {
            var response = await _mediator.Send(new DisableHospitalCommand { HospitalId = hospitalId });
            return Ok(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<HospitalDto>> GetHospitalDetails([FromQuery] int hospitalId)
        {
            var result = await _mediator.Send(new GetHospitalQuery { HospitalId = hospitalId });
            return Ok(result);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpGet("getList")]
        public async Task<ActionResult<List<HospitalDto>>> GetHospitalList()
        {
            var result = await _mediator.Send(new GetHospitalsQuery());
            return Ok(result);
        }

        [HttpPost("createRenewal")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<bool>> CreateRenewal()
        {
            var response = await _mediator.Send(new CreateRenewalCommand
            {
                RenewalDate = string.IsNullOrEmpty(Request.Form["RenewalDate"]) ? null : DateTime.Parse(Request.Form["RenewalDate"]),
                ExpireDate = string.IsNullOrEmpty(Request.Form["ExpireDate"]) ? null : DateTime.Parse(Request.Form["ExpireDate"]),
                Files = Request.Form.Files,
                HospitalId = int.Parse(Request.Form["HospitalId"]),
                Description = Request.Form["Description"],
                Title = Request.Form["Title"],
            });
            return Ok(response);
        }

        [HttpPost("updateRenewal")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<bool>> UpdateRenewal(UpdateRenewalCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("deactivateRenewal")]
        public async Task<ActionResult<bool>> DeactivateRenewal([FromQuery] int hospitalId, [FromQuery] int renewalId)
        {
            var response = await _mediator.Send(new DisableRenewalCommand { HospitalId = hospitalId, RenewalId = renewalId });
            return Ok(response);
        }

        [HttpGet("getRenewals")]
        public async Task<ActionResult<List<RenewalDto>>> GetRenewals([FromQuery] int hospitalId)
        {
            var result = await _mediator.Send(new GetRenewalsQuery { HospitalId = hospitalId });
            return Ok(result);
        }

        [HttpGet("getRenewal")]
        public async Task<ActionResult<List<RenewalDto>>> GetRenewal([FromQuery] int hospitalId, [FromQuery] int renewalId)
        {
            var result = await _mediator.Send(new GetRenewalsQuery()
            {
                RenewalId = renewalId,
                HospitalId = hospitalId
            });
            return Ok(result);
        }

        #region Empanelled TPA
        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("createEmpanelledTPA")]
        public async Task<ActionResult<bool>> CreateEmpanelledTPA(CreateEmapnelledTPACommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("updateEmpanelledTPA")]
        public async Task<ActionResult<bool>> UpdateEmpanelledTPA(UpdateEmapnelledTPACommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("deactivateEmpanelledTPA")]
        public async Task<ActionResult<bool>> DeactivateEmpanelledTPA([FromQuery] int empanelledTpaId)
        {
            var response = await _mediator.Send(new DisableTpaCommand { EmpanelledTpaId = empanelledTpaId });
            return Ok(response);
        }

        [HttpGet("getEmpanelledTPA")]
        public async Task<ActionResult<EmpanelledTpaDto>> GetEmpanelledTPA([FromQuery] int hospitalId, [FromQuery] int? empanelledTpaId)
        {
            var result = await _mediator.Send(new GetEmapnelledTpaQuery { HospitalId = hospitalId, EmpanelledTpaId = empanelledTpaId });
            return Ok(result);
        }

        [HttpGet("getEmpanelledTPAsList")]
        public async Task<ActionResult<List<EmpanelledTpaDto>>> GetEmpanelledTPAsList([FromQuery] int hospitalId)
        {
            var result = await _mediator.Send(new GetEmapnelledTpaQuery
            {
                HospitalId = hospitalId
            });
            return Ok(result);
        }
        #endregion

        #region Empanelled Insurance Company
        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("createEmpanelledIC")]
        public async Task<ActionResult<bool>> CreateEmpanelledIC(CreateEmpanelledInsuranceCompanyCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("updateEmpanelledIC")]
        public async Task<ActionResult<bool>> UpdateEmpanelledIC(UpdateEmpanelledInsuranceCompanyCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("deactivateEmpanelledIC")]
        public async Task<ActionResult<bool>> DeactivateEmpanelledIC([FromQuery] int empanelledICId)
        {
            var response = await _mediator.Send(new DisableEmpanelledInsuranceCompanyCommand { EmpanelledInsuranceCompanyId = empanelledICId });
            return Ok(response);
        }

        [HttpGet("getEmpanelledIC")]
        public async Task<ActionResult<EmpanelledInsuranceCompanyDto>> GetEmpanelledIC([FromQuery] int hospitalId, [FromQuery] int? empanelledICId)
        {
            var result = await _mediator.Send(new GetEmpanelledInsuranceCompanyQuery { HospitalId = hospitalId, EmpanelledInsuranceCompanyId = empanelledICId });
            return Ok(result);
        }

        [HttpGet("getEmpanelledICsList")]
        public async Task<ActionResult<List<EmpanelledInsuranceCompanyDto>>> GetEmpanelledICsList([FromQuery] int hospitalId)
        {
            var result = await _mediator.Send(new GetEmpanelledInsuranceCompanyQuery
            {
                HospitalId = hospitalId
            });
            return Ok(result);
        }
        #endregion

        #region Doctors Master
        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("createDoctor")]
        public async Task<ActionResult<bool>> CreateDoctor(CreateDoctorCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("updateDoctor")]
        public async Task<ActionResult<bool>> UpdateDoctor(UpdateDoctorCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("deactivateDoctor")]
        public async Task<ActionResult<bool>> DeactivateDoctor([FromQuery] int doctorId)
        {
            var response = await _mediator.Send(new DisableDoctorCommand { DoctorId = doctorId });
            return Ok(response);
        }

        [HttpGet("getDoctor")]
        public async Task<ActionResult<DoctorDto>> GetDoctor([FromQuery] int hospitalId, [FromQuery] int? doctorId)
        {
            var result = await _mediator.Send(new GetDoctorsQuery { HospitalId = hospitalId, DoctorId = doctorId });
            return Ok(result);
        }

        [HttpGet("getDoctors")]
        public async Task<ActionResult<List<DoctorDto>>> GetDoctors([FromQuery] int hospitalId)
        {
            var result = await _mediator.Send(new GetDoctorsQuery
            {
                HospitalId = hospitalId
            });
            return Ok(result);
        }
        #endregion

        #region Contacts
        [HttpPost("createContact")]
        public async Task<ActionResult<bool>> CreateContact(CreateContactCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("updateContact")]
        public async Task<ActionResult<bool>> UpdateContact(UpdateContactCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("deactivateContact")]
        public async Task<ActionResult<bool>> DeactivateContact([FromQuery] int contactId)
        {
            var response = await _mediator.Send(new DisableContactCommand { ContactId = contactId });
            return Ok(response);
        }

        [HttpGet("getContact")]
        public async Task<ActionResult<List<ContactDto>>> GetContact([FromQuery] int hospitalId, [FromQuery] int? empanelledInsCompId, [FromQuery] int? empanelledTpaId, [FromQuery] int? contactId)
        {
            var result = await _mediator.Send(new GetContactsQuery { HospitalId = hospitalId, ContactId = contactId, EmpanelledInsCompId = empanelledInsCompId, EmpanelledTpaId = empanelledTpaId });
            return Ok(result);
        }

        [HttpGet("getContacts")]
        public async Task<ActionResult<List<ContactDto>>> GetContacts([FromQuery] int hospitalId, [FromQuery] int? empanelledInsCompId, [FromQuery] int? empanelledTpaId)
        {
            var result = await _mediator.Send(new GetContactsQuery
            {
                HospitalId = hospitalId,
                EmpanelledInsCompId = empanelledInsCompId,
                EmpanelledTpaId = empanelledTpaId
            });
            return Ok(result);
        }
        #endregion

        #region MOU
        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("createMou")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<bool>> CreateMou()
        {
            var response = await _mediator.Send(new CreateMouCommand
            {
                Files = Request.Form.Files,
                EmpanelledInsCompId = string.IsNullOrEmpty(Request.Form["EmpanelledInsComp"]) ? null : int.Parse(Request.Form["EmpanelledInsComp"]),
                EmpanelledTpaId = string.IsNullOrEmpty(Request.Form["EmpanelledTpa"]) ? null : int.Parse(Request.Form["EmpanelledTpa"]),
                MouStartDate = string.IsNullOrEmpty(Request.Form["MouStartDate"]) ? null : DateTime.Parse(Request.Form["MouStartDate"]),
                MouEndDate = string.IsNullOrEmpty(Request.Form["MouEndDate"]) ? null : DateTime.Parse(Request.Form["MouEndDate"]),
                DocName = Request.Form["DocName"],
                HospitalId = int.Parse(Request.Form["HospitalId"]),
            });
            return Ok(response);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("updateMou")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<bool>> UpdateMou(UpdateMouCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("getMous")]
        public async Task<ActionResult<GetMousQueryResponse>> GetMous([FromQuery] int hospitalId, [FromQuery] int? empanelledInsCompId, [FromQuery] int? empanelledTpaId, [FromQuery] int? mouId)
        {
            var result = await _mediator.Send(new GetMousQuery { HospitalId = hospitalId, EmpanelledInsCompId = empanelledInsCompId, EmpanelledTpaId = empanelledTpaId, MouId = mouId });
            return Ok(result);
        }

        [Authorize(Policy = "ProviderAdminOnly")]
        [HttpPost("deactivateMou")]
        public async Task<ActionResult<bool>> DeactivateMou([FromQuery] int mouId)
        {
            var response = await _mediator.Send(new DisableMouCommand { MouId = mouId });
            return Ok(response);
        }
        #endregion

        #region Hospital Users
        [Authorize(Policy = "BothAdmins")]
        [HttpPost("createUser")]
        public async Task<ActionResult<bool>> CreateUser(CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "BothAdmins")]
        [HttpPost("updateUser")]
        public async Task<ActionResult<bool>> UpdateUser(UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Policy = "BothAdmins")]
        [HttpPost("deactivateUser")]
        public async Task<ActionResult<bool>> DeactivateUser([FromQuery] int userId, [FromQuery] int hospitalId)
        {
            var response = await _mediator.Send(new DisableUserCommand { UserId = userId, HospitalId = hospitalId });
            return Ok(response);
        }

        [HttpGet("getUsers")]
        public async Task<ActionResult<List<UserDto>>> GetUsers([FromQuery] int hospitalId, [FromQuery] int? userId)
        {
            var result = await _mediator.Send(new GetUsersQuery { HospitalId = hospitalId, UserId = userId });
            return Ok(result);
        }
        #endregion

        #region Hospital Data
        [HttpGet("getHospitalData")]
        public async Task<ActionResult<GetHospitalDataResponse>> GetHospitalData([FromQuery] int hospitalId)
        {
            var result = await _mediator.Send(new GetHospitalDataQuery { HospitalId = hospitalId });
            return Ok(result);
        }
        #endregion
    }
}
