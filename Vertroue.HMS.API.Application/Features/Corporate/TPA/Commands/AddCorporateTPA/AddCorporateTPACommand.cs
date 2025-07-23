using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.AddCorporateTPA
{
    public record AddCorporateTPACommand(
    int CorporateId,
    int UserId,
    string UserType,
    string UserRole,
    string EmpanneledDate,
    string PortalLink,
    string PortalUserId,
    string PortalPassword,
    int TPAId
) : IRequest<string>;
}
