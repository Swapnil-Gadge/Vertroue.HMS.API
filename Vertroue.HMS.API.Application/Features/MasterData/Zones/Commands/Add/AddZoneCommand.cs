using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.Zone.Commands.Add
{
    public class AddZoneCommand : IRequest<string>
    {
        public string ZoneName { get; set; }
        public int UserId { get; set; }
    }
}