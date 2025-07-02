using Vertroue.HMS.API.Application.Features.Dashboards.Models;

namespace Vertroue.HMS.API.Application.Features.Dashboards.Queries.GetProviderAdminDashboard
{
    public class GetProviderAdminDashboardResponse
    {
        public List<CaseCounts> CaseCounts { get; set; }

        public List<TatReportCase> TatReportCases { get; set; }

        public List<string?> TATReports {  get; set; }
        
        public List<string?> TotalCaseBiFurcations { get; set; }

        public List<Defficiency> Defficiencies { get; set; }

        public List<Denial> Denials { get; set; }
    }
}
