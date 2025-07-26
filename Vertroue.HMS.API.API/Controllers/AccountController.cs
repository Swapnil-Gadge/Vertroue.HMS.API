using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Users.Commands.Login;
using Vertroue.HMS.API.Application.Features.Users.Commands.Register;
using Vertroue.HMS.API.Application.Features.Users.Commands.UpdatePassword;
using Vertroue.HMS.API.Application.Features.Users.Queries.ValidateLogin;
using Vertroue.HMS.API.Application.Responses;

namespace Vertroue.HMS.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpPost("register")]
        public async Task<ActionResult<BaseResponse>> Register(string userName, string password)
        {
            var response = await _mediator.Send(new UserRegisterCommand
            {
                UserName = userName,
                Password = password
            });

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse>> Login(string userName, string password)
        {
            var response = await _mediator.Send(new LoginCommand
            {
                UserName = userName,
                Password = password
            });

            return Ok(response);
        }

        [HttpGet("validate-login")]
        public async Task<IActionResult> ValidateLogin([FromQuery] string UserId, [FromQuery] string UserPass ,[FromQuery] string UserType)
        {
            var query = new ValidateLoginQuery
            {                
                UserId = UserId,
                Password = UserPass,
                UserType = UserType
            }; 
            var result = await _mediator.Send(query);
            if (result == null)
                return Unauthorized("Invalid credentials");

            return Ok(result);
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommand command)
        {
            var success = await _mediator.Send(command);

            if (!success)
                return BadRequest("Password update failed. Please verify your current password.");

            return Ok("Password updated successfully.");
        }
    }
}
