namespace Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Model
{
    public class CorporatePlanDto
    {
        public int CorporatePlanId { get; set; }
        public string CorporatePlanName { get; set; }
        public string CorporatePlanDescription { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}