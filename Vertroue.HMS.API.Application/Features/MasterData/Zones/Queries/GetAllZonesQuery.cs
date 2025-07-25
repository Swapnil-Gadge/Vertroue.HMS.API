using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.Zones.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.Zone.Queries
{
    public class GetAllZonesQuery : IRequest<List<ZoneDto>> { }
}