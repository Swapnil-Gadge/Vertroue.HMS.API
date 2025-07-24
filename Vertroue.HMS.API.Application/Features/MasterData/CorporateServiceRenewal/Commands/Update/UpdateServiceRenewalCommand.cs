using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Commands.Update
{
    public record UpdateServiceRenewalCommand(
        int? ServiceRenewalId,
        string ServiceRenewalName,
        string ServiceRenewalDesc,
        int UserId
    ) : IRequest<string>;
}