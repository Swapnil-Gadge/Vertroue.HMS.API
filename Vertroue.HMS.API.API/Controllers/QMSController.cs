using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Commands;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Queries;
using Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Commands;
using Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Queries;
using Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Add;
using Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Enhancement;
using Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Update;
using Vertroue.HMS.API.Application.Features.QMS.QMSControl.Queries;

namespace Vertroue.HMS.API.API.Controllers
{
    [ApiController]
    [Authorize]
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

        //[HttpPost("payment-received/list")]
        //public async Task<IActionResult> GetPaymentReceived([FromBody] GetPaymentReceivedQuery query)
        //{
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}


        [HttpGet("payment-received/list")]
        public async Task<IActionResult> GetPaymentReceived([FromQuery] int corporateId, [FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
        {
            var query = new GetPaymentReceivedQuery
            {
                CorporateId = corporateId,
                UserId = userId,
                UserType = userType,
                UserRole = userRole
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("updatePaymentReceived")]
        public async Task<IActionResult> UpdateCorporatePaymentReceived([FromBody] UpdateCorporatePendingPaymentReceivedCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { Message = result });
        }

        [HttpGet("FetchAllControlsList")]
        public async Task<IActionResult> FetchAllQMSControlsList([FromQuery] int corporateId, [FromQuery] int userId, [FromQuery] string userType, [FromQuery] string userRole)
        {
            var query = new FetchAllQMSControlsListQuery
            {
                CorporateId = corporateId,
                UserId = userId,
                UserType = userType,
                UserRole = userRole
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("CreateQMSCase")]
        public async Task<IActionResult> CreateQMSCase([FromBody] CreateQMSCaseCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("UpdateQMSCase")]
        public async Task<IActionResult> UpdateQMSCase([FromBody] UpdateQMSCaseCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("UpdateCaseEnhancement")]
        public async Task<IActionResult> UpdateCaseEnhancement([FromBody] UpdateCaseEnhancementCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

