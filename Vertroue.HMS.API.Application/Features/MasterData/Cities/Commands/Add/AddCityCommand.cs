using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.Cities.Commands.Add;

public record AddCityCommand(
    string CityName,
    int StateId,
    int UserId
) : IRequest<string>;