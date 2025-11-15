using MediatR;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.DeleteClaimFlowDoc
{
    public class DeleteClaimFlowDocCommand : IRequest<bool>
    {
        public int ClaimFlowDocId { get; set; }
    }
}
