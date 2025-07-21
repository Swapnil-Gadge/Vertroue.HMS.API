namespace Vertroue.HMS.API.Application.Features.Corporate.Details.Model
{
    public class CorporateDetailsDto
    {
        public int CorporateId { get; set; }
        public int ParentCorporateId { get; set; }
        public string ParentCorporateName { get; set; }
        public string CorporateName { get; set; }
        public string CorporateType { get; set; }
        public string CorporateAddress { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string Pincode { get; set; }
        public string ContactNo { get; set; }
        public string Zone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class CorporateExtraDetailsDto
    {
        public int CorporateId { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDetails { get; set; }
        public string ColumnName1 { get; set; }
        public string ColumnDetails1 { get; set; }
    }
}
