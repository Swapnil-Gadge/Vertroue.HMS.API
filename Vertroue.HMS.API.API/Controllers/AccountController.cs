using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vertroue.HMS.API.Application.Features.Users.Commands.Login;
using Vertroue.HMS.API.Application.Features.Users.Commands.Register;
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

        [Authorize]
        [HttpPost("validate-token")]
        public async Task<ActionResult<BaseResponse>> ValidateToken()
        {
            return Ok(new BaseResponse
            {
                Message = "Authorized",
                Success = true
            });
        }
    }
}
