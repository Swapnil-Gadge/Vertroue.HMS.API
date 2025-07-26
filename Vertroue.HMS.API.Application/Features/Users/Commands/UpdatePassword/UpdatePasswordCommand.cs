using MediatR;

namespace Vertroue.HMS.API.Application.Features.Users.Commands.UpdatePassword
{
    public class UpdatePasswordCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
