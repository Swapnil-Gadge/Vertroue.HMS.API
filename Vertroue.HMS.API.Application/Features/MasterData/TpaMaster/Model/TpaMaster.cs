namespace Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Model
{
    public class TpaMasterDto
    {
        public int TPA_Id { get; set; }
        public string TP_Name { get; set; }
        public string License_Number { get; set; }
        public string License_Validity { get; set; }
        public string Chief_Executive_Officer { get; set; }
        public string TPA_Address { get; set; }
        public string Senior_Citizen_Helpline { get; set; }
        public string Toll_Free_Number { get; set; }
        public string TPA_Email { get; set; }
        public string TPA_Website { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
