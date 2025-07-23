using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Modify
{
    public record ModifyCorporateInsurerCommand(
        int CorporateInsurerId,
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
