namespace Vertroue.HMS.API.Application.Features.MasterData.States.Model
{
    public class StateDto
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateZone { get; set; }
        public string ZoneName { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
