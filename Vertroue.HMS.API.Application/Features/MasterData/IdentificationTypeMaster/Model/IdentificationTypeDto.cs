namespace Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Model
{
    public class IdentificationTypeDto
    {
        public int IdentificationTypeId { get; set; }
        public string IdentificationTypeName { get; set; }
        public string IdentificationTypeDescription { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}