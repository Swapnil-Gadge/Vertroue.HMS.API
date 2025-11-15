using MediatR;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.UpdateClaimStatus
{
    public class UpdateClaimStatusCommand : IRequest<bool>
    {
        public int PatientId { get; set; }

        public int HospitalId { get; set; }

        public string? Status { get; set; }
    }
}
