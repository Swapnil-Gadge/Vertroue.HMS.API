using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Commands.Add
{
    public record AddServiceRenewalCommand(
        int? ServiceRenewalId,
        string ServiceRenewalName,
        string ServiceRenewalDesc,
        int UserId
    ) : IRequest<string>;
}