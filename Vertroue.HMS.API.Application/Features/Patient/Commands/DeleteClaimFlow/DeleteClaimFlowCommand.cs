using MediatR;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.DeleteClaimFlow
{
    public class DeleteClaimFlowCommand : IRequest<bool>
    {
        public int ClaimFlowId { get; set; }

        public int HospitalId { get; set; }
    }
}
