using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableRenewal
{
    public class DisableRenewalCommand : IRequest<bool>
    {
        public int RenewalId { get; set; }

        public int HospitalId { get; set; }
    }
}
