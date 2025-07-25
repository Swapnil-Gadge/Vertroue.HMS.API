using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Commands.Deactivate
{
    public class DeactivateStatusProcessFlowCommand : IRequest<string>
    {
        public int StatusProcessId { get; set; }
        public int UserId { get; set; }
    }
}
