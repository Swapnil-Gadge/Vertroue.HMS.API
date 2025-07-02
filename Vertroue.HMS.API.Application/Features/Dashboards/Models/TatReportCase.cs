namespace Vertroue.HMS.API.Application.Features.Dashboards.Models
{
    public class TatReportCase
    {
        public int TableId { get; set; }

        public int? CaseDetailsId { get; set; }

        public DateTime? CaseInitiateDate { get; set; }

        public DateTime? CaseDeffRecvDate { get; set; }

        public DateTime? CaseDeffRespDate { get; set; }

        public DateTime? CaseApprovalDate { get; set; }

        public decimal? CaseDeffTat { get; set; }

        public decimal? CaseApprTat { get; set; }

        public decimal? TatInHrs { get; set; }
    }
}
