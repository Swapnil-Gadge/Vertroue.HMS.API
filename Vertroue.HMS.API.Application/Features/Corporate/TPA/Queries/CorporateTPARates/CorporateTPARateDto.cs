namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Queries.CorporateTPARates
{
    public class CorporateTPARateDto
    {
        public int CorporateTPARatesId { get; set; }
        public int CorporateTPAId { get; set; }
        public DateTime? RateActiveFromDate { get; set; }
        public DateTime? RateActiveToDate { get; set; }
        public string? RateListDocument { get; set; }
        public string? RateRemarks { get; set; }
        public string? ActiveFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
