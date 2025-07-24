using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.Models;

namespace Vertroue.HMS.API.Application.Features.MasterData.Queries.GetMasterData
{
    public record FetchCitiesQuery(int StateId) : IRequest<List<CityDto>>;
}
