using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Patient.Commands.CreatePatientDoc;
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
