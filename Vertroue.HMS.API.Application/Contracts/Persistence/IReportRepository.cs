using Vertroue.HMS.API.Application.Features.Reports.Model;
using Vertroue.HMS.API.Application.Features.Reports.Queries;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IReportRepository
    {
        Task<List<CorporateCasePendingReportDto>> FetchCorporateCasePendingReportAsync(GetCorporateCasePendingReportQuery request);
    }
}
