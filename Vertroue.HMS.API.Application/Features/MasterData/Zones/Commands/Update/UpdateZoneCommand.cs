using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.Zone.Commands.Update
{
    public class UpdateZoneCommand : IRequest<string>
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int UserId { get; set; }
    }
}