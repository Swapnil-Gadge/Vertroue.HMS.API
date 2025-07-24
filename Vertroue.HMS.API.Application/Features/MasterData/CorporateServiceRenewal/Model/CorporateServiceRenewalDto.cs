namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Model
{
    public class CorporateServiceRenewalDto
    {
        public int ServiceRenewalId { get; set; }
        public string ServiceRenewalName { get; set; }
        public string ServiceRenewalDesc { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}