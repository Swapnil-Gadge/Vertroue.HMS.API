using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.States.Commands.Update
{
    public class UpdateStateCommand : IRequest<string>
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateZone { get; set; }
        public int UserId { get; set; }
    }
}
