using MediatR;
using Vertroue.HMS.API.Application.Responses;

namespace Vertroue.HMS.API.Application.Features.Users.Commands.Register
{
    public class UserRegisterCommand : IRequest<BaseResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
