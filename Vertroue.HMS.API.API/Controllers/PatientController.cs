using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlow;
using Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlowDoc;
using Vertroue.HMS.API.Application.Features.Patient.Commands.CreatePatient;
using Vertroue.HMS.API.Application.Features.Patient.Commands.CreatePatientDoc;
using Vertroue.HMS.API.Application.Features.Patient.Commands.DeleteClaimFlow;
using Vertroue.HMS.API.Application.Features.Patient.Commands.DeleteClaimFlowDoc;
using Vertroue.HMS.API.Application.Features.Patient.Commands.DeletePatientDoc;
using Vertroue.HMS.API.Application.Features.Patient.Commands.UpdateClaimFlow;
using Vertroue.HMS.API.Application.Features.Patient.Commands.UpdateClaimStatus;
using Vertroue.HMS.API.Application.Features.Patient.Commands.UpdatePatient;
using Vertroue.HMS.API.Application.Features.Patient.Queries.GetPatient;
using Vertroue.HMS.API.Application.Features.Patient.Queries.GetPatients;
using Vertroue.HMS.API.Application.Models.Patient;

namespace Vertroue.HMS.API.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientDto>>> GetAllPatients()
        {
            //var query = new GetAllPatientsQuery(); // Assuming you have a query defined
            //var patients = await _mediator.Send(query);
            return Ok(new List<PatientDto>());
        }

        [HttpPost("uploadPatientDoc")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> CreatePatientDoc()
        {
            var response = await _mediator.Send(new CreatePatientDocCommand
            {
                Files = Request.Form.Files,
                PatientId = int.Parse(Request.Form["PatientId"]),
                DocumentType = Request.Form["DocumentType"],
            });
            return Ok(response);
        }

        [HttpPost("uploadClaimFlowDoc")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> CreateClaimFlowDoc()
        {
            var response = await _mediator.Send(new CreateClaimFlowDocCommand
            {
                Files = Request.Form.Files,
                Id = int.Parse(Request.Form["Id"]),
                FileName = Request.Form["FileName"],
            });
            return Ok(response);
        }

        [HttpPost("deletePatientDoc")]
        public async Task<ActionResult<bool>> DeletePatientDoc([FromQuery] int patientDocId)
        {
            var response = await _mediator.Send(new DeletePatientDocCommand
            {
                PatientDocId = patientDocId
            });
            return Ok(response);
        }

        [HttpPost("deleteClaimFlowDoc")]
        public async Task<ActionResult<bool>> DeleteClaimFlowDoc([FromQuery] int claimFlowDocId)
        {
            var response = await _mediator.Send(new DeleteClaimFlowDocCommand
            {
                ClaimFlowDocId = claimFlowDocId
            });
            return Ok(response);
        }

        [HttpPost("createPatient")]
        public async Task<ActionResult<PatientDto>> CreatePatient(CreatePatientCommand command)
        {
            try
            {
                var createdPatient = await _mediator.Send(command);
                return Ok(createdPatient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }            
        }

        [HttpPost("updatePatient")]
        public async Task<ActionResult<PatientDto>> UpdatePatient(UpdatePatientCommand command)
        {
            try
            {
                var updatedPatient = await _mediator.Send(command);
                return Ok(updatedPatient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("updateClaimStatus")]
        public async Task<ActionResult<PatientDto>> UpdateClaimStatus([FromQuery] int patientId, [FromQuery] int hospitalId, [FromQuery] string newStatus)
        {
            try
            {
                var updatedPatient = await _mediator.Send(new UpdateClaimStatusCommand
                {
                    HospitalId = hospitalId,
                    PatientId = patientId,
                    Status = newStatus
                });
                return Ok(updatedPatient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpGet("getPatientById")]
        public async Task<ActionResult<PatientDto>> GetPatientById([FromQuery] int patientId, [FromQuery] int hospitalId)
        {
            var query = new GetPatientQuery { PatientId = patientId, HospitalId = hospitalId }; 
            var patient = await _mediator.Send(query);
            return Ok(patient);
        }

        [HttpGet("getAllPatients")]
        public async Task<ActionResult<List<PatientDto>>> GetAllPatients([FromQuery] int hospitalId)
        {
            var query = new GetPatientsQuery { HospitalId = hospitalId };
            var patients = await _mediator.Send(query);
            return Ok(patients);
        }

        [HttpPost("createClaimFlow")]
        public async Task<ActionResult<ClaimFlowDto>> CreateClaimFlow(CreateClaimFlowCommand command)
        {
            var createdClaimFlow = await _mediator.Send(command);
            return Ok(createdClaimFlow);
        }

        [HttpPost("UpdateClaimFlow")]
        public async Task<ActionResult<ClaimFlowDto>> UpdateClaimFlow(UpdateClaimFlowCommand command)
        {
            var updatedClaimFlow = await _mediator.Send(command);
            return Ok(updatedClaimFlow);
        }

        [HttpPost("deleteClaimFlow")]
        public async Task<ActionResult<bool>> DeleteClaimFlow([FromQuery] int claimFlowId, [FromQuery] int hospitalId)
        {
            var result = await _mediator.Send(new DeleteClaimFlowCommand
            {
                ClaimFlowId = claimFlowId,
                HospitalId = hospitalId
            });
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPatientById(int id)
        //{
        //    var patient = await _patientService.GetPatientByIdAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(patient);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var createdPatient = await _patientService.CreatePatientAsync(patientDto);
        //    return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.Id }, createdPatient);
        //}
    }
}
