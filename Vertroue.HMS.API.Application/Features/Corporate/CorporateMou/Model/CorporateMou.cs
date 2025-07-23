namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Model
{
    public class CorporateMouDto
    {
        public int Tbl_Id { get; set; }
        public int CorporateMOUId { get; set; }
        public int CorporateId { get; set; }
        public DateTime? ActiveFromDate { get; set; }
        public DateTime? ActiveToDate { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentLink { get; set; }
        public string? Remarks { get; set; }
        public string? ActiveFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
