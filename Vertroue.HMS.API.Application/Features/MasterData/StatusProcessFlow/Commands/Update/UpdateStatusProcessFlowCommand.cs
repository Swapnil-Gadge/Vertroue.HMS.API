using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Commands.Update
{
    public class UpdateStatusProcessFlowCommand : IRequest<string>
    {
        public int StatusProcessId { get; set; }
        public int PostStatusId { get; set; }
        public int UserId { get; set; }
    }
}
