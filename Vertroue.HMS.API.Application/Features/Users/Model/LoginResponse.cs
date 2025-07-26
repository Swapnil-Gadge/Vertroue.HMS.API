
namespace Vertroue.HMS.API.Application.Features.Users.Model
{
    public class LoginResponseDto
    {
        public int UserLoginId { get; set; }
        public int CorporateId { get; set; }
        public int UserTypeId { get; set; }
        public int UserRoleId { get; set; }
        public string UserName { get; set; }
        public string UserRoleName { get; set; }
        public string UserTypeName { get; set; }
        public bool PasswordExpireFlag { get; set; }
        public string LastChangePasswordDate { get; set; }
        public string UserSessionId { get; set; }
        public int CorporateIdAgain { get; set; }
        public string CorporateName { get; set; }
        public string CorporateType { get; set; }
        public string ServiceActiveFlag { get; set; }
        public string ServiceStartDate { get; set; }
        public string ServiceEndDate { get; set; }
        public string ServiceLapsedFlag { get; set; }
    }
}
