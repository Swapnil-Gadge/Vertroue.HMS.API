using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.ModifyCorporateTPA
{
    public record ModifyCorporateTPACommand(
    int CorporateTPAId,
    int CorporateId,
    int UserId,
    string UserType,
    string UserRole,
    string EmpanneledDate,
    string PortalLink,
    string PortalUserId,
    string PortalPassword
) : IRequest<string>;
}
