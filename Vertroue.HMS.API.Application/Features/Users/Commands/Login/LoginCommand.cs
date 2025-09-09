using MediatR;

namespace Vertroue.HMS.API.Application.Features.Users.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string UserRole { get; set; }
    }
}
