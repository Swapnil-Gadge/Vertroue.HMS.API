namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Model
{
    public class CorporateUserDto
    {
        public int ContactPersonId { get; set; }
        public int CorporateId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
