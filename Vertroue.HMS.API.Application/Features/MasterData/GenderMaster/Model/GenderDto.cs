namespace Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Model
{
    public class GenderDto
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}