using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableContact
{
    public class DisableContactCommand : IRequest<bool>
    {
        public int ContactId { get; set; }

        public int HospitalId { get; set; }
    }
}
