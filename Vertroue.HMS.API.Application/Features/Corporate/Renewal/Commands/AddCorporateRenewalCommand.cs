using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Commands
{
    public record AddCorporateRenewalCommand(
        int CorporateId,
        int UserId,
        string UserType,
        string UserRole,
        string ServiceDesc,
        string RenewalDate,
        string ExpireDate,
        int ServiceRenewalId
    ) : IRequest<string>;
}
