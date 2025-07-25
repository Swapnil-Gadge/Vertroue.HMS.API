using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Commands;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Queries;

namespace Vertroue.HMS.API.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QMSController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QMSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("corporate-pending-filesent")]
        public async Task<IActionResult> GetCorporatePendingFilesent([FromQuery] int corporateId, [FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
        {
            var query = new GetCorporatePendingFileSentQuery
            {
                CorporateId = corporateId,
                UserId = userId,
                UserType = userType,
                UserRole = userRole
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("update-file-sent")]
        public async Task<IActionResult> UpdateFileSent([FromBody] UpdateCorporateFileSentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { message = result });
        }
    }
}

