using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.Cities.Models;

namespace Vertroue.HMS.API.Application.Features.MasterData.Cities.Queries;

public record FetchCityMasterQuery : IRequest<List<CityMasterDto>>;