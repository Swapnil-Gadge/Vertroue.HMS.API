
using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Commands.Update
{
    public record UpdateCorporatePlanCommand(
        int? CorporatePlanId,
        string CorporatePlanName,
        string CorporatePlanDescription,
        int UserId
    ) : IRequest<string>;
}
