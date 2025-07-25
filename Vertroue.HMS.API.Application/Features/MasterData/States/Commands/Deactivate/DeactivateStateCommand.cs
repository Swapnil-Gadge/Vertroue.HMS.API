using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.States.Commands.Deactivate
{
    public class DeactivateStateCommand : IRequest<string>
    {
        public int StateId { get; set; }
        public int UserId { get; set; }
    }
}
