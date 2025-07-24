namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Model
{
    public class CorporateTypeMasterDto
    {
        public int CorporateTypeId { get; set; }
        public string CorporateTypeName { get; set; }
        public string CorporateTypeDescription { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }

}
