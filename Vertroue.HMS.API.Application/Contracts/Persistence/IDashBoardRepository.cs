using Vertroue.HMS.API.Application.Features.Dashboards.Models;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IDashBoardRepository
    {
        Task<(List<CaseCounts>, List<TatReportCase>, List<Denial>, List<Defficiency>, List<string?>, List<string?>)> GetProviderAdminDashboardData(int corpId, int loginId, string userType, string userRole);
    }
}
