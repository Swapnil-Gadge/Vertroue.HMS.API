namespace Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Model
{
    public class StatusProcessFlowDto
    {
        public int StatusProcessId { get; set; }
        public int StatusId { get; set; }
        public string CurrentStatus { get; set; }
        public int PostStatusId { get; set; }
        public string PostStatus { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
