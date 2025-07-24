using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.Cities.Commands.Modify;

public record ModifyCityCommand(
    int CityId,
    string CityName,
    int StateId,
    int UserId
) : IRequest<string>;