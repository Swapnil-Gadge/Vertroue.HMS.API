using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableUser
{
    public class DisableUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }

        public int HospitalId { get; set; }
    }
}
