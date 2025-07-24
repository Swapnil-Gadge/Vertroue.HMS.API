using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.Cities.Commands.Deactivate;

public record DeactivateCityCommand(
    int CityId,
    int UserId
) : IRequest<string>;