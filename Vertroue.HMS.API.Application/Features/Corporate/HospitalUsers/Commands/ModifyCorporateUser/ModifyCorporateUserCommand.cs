using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.ModifyCorporateUser
{
    public record ModifyCorporateUserCommand(
        int CorporateId,
        int UserId,
        string UserType,
        string UserRole,
        string FirstName,
        string MiddleName,
        string LastName,
        string MobileNo,
        int ContactPersonId
    ) : IRequest<string>;
}
