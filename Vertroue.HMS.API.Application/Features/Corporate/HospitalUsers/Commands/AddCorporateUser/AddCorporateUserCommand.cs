using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.AddCorporateUser
{
    public record AddCorporateUserCommand(
        int CorporateId,
        int UserId,
        string UserType,
        string UserRole,
        string FirstName,
        string MiddleName,
        string LastName,
        string MobileNo,
        string EmailId,
        int UserRoleId
    ) : IRequest<string>;
}
