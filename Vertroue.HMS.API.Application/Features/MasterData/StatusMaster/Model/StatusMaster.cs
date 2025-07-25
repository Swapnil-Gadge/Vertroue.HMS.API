namespace Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Model
{
    public class StatusMasterDto
    {
        public int Status_Id { get; set; }
        public string Status_Name { get; set; }
        public string Status_Desc { get; set; }
        public string Status_Action_Owner { get; set; }
        public string Status_Post_Action_Owner { get; set; }
        public string Active_Flag { get; set; }
        public string Created_date { get; set; }
        public string Created_by { get; set; }
        public string Modifed_date { get; set; }
        public string Modified_by { get; set; }
    }
}