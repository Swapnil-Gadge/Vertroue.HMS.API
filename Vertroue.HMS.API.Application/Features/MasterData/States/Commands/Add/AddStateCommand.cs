using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.States.Commands.Add
{
    public class AddStateCommand : IRequest<string>
    {
        public string StateName { get; set; }
        public string StateZone { get; set; }
        public int UserId { get; set; }
    }
}
