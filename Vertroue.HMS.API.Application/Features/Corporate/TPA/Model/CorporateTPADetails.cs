namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Model
{
    public class CorporateTPADetailsDto
    {
        public int CorporateTPAId { get; set; }
        public int CorporateId { get; set; }
        public string? TPAName { get; set; }
        public DateTime? EmpanneledDate { get; set; }
        public string? PortalLink { get; set; }
        public string? PortalUserId { get; set; }
        public string? PortalPassword { get; set; }
        public string? ActiveFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }

    public class TPAMasterDto
    {
        public int TPAId { get; set; }
        public string? TPName { get; set; }
        public string? LicenseNumber { get; set; }
        public DateTime? LicenseValidity { get; set; }
        public string? ChiefExecutiveOfficer { get; set; }
        public string? TPAAddress { get; set; }
        public string? SeniorCitizenHelpline { get; set; }
        public string? TollFreeNumber { get; set; }
        public string? TPAEmail { get; set; }
        public string? TPAWebsite { get; set; }
        public string? ActiveFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
