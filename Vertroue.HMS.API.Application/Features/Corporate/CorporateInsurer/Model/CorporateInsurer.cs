
namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Model
{
    public class CorporateInsurerDto
    {
        public int CorporateInsurerId { get; set; }
        public int CorporateId { get; set; }
        public string? InsurerName { get; set; }
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

    public class InsurerMasterDto
    {
        public int InsurerId { get; set; }
        public string? InsurerName { get; set; }
        public string? InsurerCode { get; set; }
        public string? ActiveFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }

}
