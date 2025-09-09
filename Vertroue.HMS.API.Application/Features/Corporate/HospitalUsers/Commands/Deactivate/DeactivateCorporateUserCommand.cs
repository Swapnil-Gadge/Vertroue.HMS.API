using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.ModifyCorporateUser
{
    public class DeactivateCorporateUserCommand : IRequest<string>
    {
        public int ContactPersonId { get; set; }
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
