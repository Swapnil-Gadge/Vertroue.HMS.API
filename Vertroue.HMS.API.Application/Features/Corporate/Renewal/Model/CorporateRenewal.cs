namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Model
{
    public class CorporateRenewalDto
    {
        public int CorporateServiceRenewalId { get; set; }
        public int CorporateId { get; set; }
        public string? ServiceRenewalName { get; set; }
        public string? ServiceDesc { get; set; }
        public DateTime? RenewalDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string? RenewalFlag { get; set; }
        public string? ActiveFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }

    public class CorporateRenewalDetailsDto
    {
        public int Service_Renewal_id { get; set; }
        public string? Service_Renewal_Name { get; set; }
        public string? Service_Renewal_Desc { get; set; }
        public string? Active_Flag { get; set; }

        public DateTime? Created_date { get; set; }
        public string? Created_By { get; set; }

        public DateTime? Modifed_date { get; set; }
        public string? Modifed_By { get; set; }
    }
}
