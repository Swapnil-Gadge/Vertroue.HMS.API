
using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Commands.Add
{
    public record AddCorporatePlanCommand(
        int? CorporatePlanId,
        string CorporatePlanName,
        string CorporatePlanDescription,
        int UserId
    ) : IRequest<string>;
}
