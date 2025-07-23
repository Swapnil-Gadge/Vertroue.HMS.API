using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.ModifyCorporateUser
{
    public record DeactivateCorporateUserCommand(
        int ContactPersonId,
        int CorporateId,
        int UserId,
        string UserType,
        string UserRole
    ) : IRequest<string>;
}
