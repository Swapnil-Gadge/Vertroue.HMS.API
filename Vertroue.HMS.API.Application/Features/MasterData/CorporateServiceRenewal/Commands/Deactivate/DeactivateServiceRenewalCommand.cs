using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Commands.Deactivate
{
    public record DeactivateServiceRenewalCommand(
        int? ServiceRenewalId,
        string ServiceRenewalName,
        string ServiceRenewalDesc,
        int UserId
    ) : IRequest<string>;
}