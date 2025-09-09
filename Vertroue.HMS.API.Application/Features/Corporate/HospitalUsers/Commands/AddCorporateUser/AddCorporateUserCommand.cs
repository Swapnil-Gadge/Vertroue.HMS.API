using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.AddCorporateUser
{
    public class AddCorporateUserCommand : IRequest<string>
    {
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int UserRoleId { get; set; }
    }
}
