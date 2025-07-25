using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.Zone.Commands.Deactivate
{
    public class DeactivateZoneCommand : IRequest<string>
    {
        public int ZoneId { get; set; }
        public int UserId { get; set; }
    }
}