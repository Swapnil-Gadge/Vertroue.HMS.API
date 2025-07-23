using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Deactivate
{
    public record DeactivateCorporateInsurerCommand(
    int CorporateInsurerId,
    int CorporateId,
    int UserId,
    string UserType,
    string UserRole
) : IRequest<string>;
}
