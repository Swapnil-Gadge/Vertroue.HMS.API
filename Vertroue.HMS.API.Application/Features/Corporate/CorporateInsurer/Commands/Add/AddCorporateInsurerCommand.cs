using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Add
{
    public record AddCorporateInsurerCommand(
    int CorporateId,
    int UserId,
    string UserType,
    string UserRole,
    string EmpanneledDate,
    string PortalLink,
    string PortalUserId,
    string PortalPassword,
    int InsurerId
) : IRequest<string>;
}
