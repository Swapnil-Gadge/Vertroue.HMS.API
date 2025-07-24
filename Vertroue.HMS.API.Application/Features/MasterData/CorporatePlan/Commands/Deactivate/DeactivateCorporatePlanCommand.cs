
using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Commands.Deactivate
{
    public record DeactivateCorporatePlanCommand(
        int? CorporatePlanId,
        string CorporatePlanName,
        string CorporatePlanDescription,
        int UserId
    ) : IRequest<string>;
}
