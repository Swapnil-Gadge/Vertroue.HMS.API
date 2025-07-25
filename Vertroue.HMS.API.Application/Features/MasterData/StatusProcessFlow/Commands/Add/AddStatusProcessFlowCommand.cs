using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Commands.Add
{
    public class AddStatusProcessFlowCommand : IRequest<string>
    {
        public int StatusId { get; set; }
        public int PostStatusId { get; set; }
        public int UserId { get; set; }
    }
}
