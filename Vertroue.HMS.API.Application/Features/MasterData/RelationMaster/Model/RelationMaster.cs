namespace Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Model
{
    public class RelationMasterDto
    {
        public int RelationId { get; set; }
        public string RelationCode { get; set; }
        public string RelationName { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
