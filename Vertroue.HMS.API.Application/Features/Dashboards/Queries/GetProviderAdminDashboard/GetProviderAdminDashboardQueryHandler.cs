using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Dashboards.Queries.GetProviderAdminDashboard
{
    public class GetProviderAdminDashboardQueryHandler : IRequestHandler<GetProviderAdminDashboardQuery, GetProviderAdminDashboardResponse>
    {
        private readonly IDashBoardRepository _dashBoardRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetProviderAdminDashboardQueryHandler(IDashBoardRepository dashBoardRepository,
            ILoggedInUserService loggedInUserService)
        {
            _dashBoardRepository = dashBoardRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<GetProviderAdminDashboardResponse> Handle(GetProviderAdminDashboardQuery request, CancellationToken cancellationToken)
        {
            var result =  await _dashBoardRepository.GetProviderAdminDashboardData(_loggedInUserService.CorporateId,
                _loggedInUserService.UserLoginId,
                _loggedInUserService.UserType,
                _loggedInUserService.UserRole);
            return new GetProviderAdminDashboardResponse
            {
                CaseCounts = result.Item1,
                TatReportCases = result.Item2,
                Denials = result.Item3,
                Defficiencies = result.Item4,
                TATReports = result.Item5,
                TotalCaseBiFurcations = result.Item6,
            };
        }
    }
}
