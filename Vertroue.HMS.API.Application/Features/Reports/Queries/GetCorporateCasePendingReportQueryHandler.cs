using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Reports.Model;

namespace Vertroue.HMS.API.Application.Features.Reports.Queries
{
    public class GetCorporateCasePendingReportQueryHandler : IRequestHandler<GetCorporateCasePendingReportQuery, List<CorporateCasePendingReportDto>>
    {
        private readonly IReportRepository _repo;

        public GetCorporateCasePendingReportQueryHandler(IReportRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CorporateCasePendingReportDto>> Handle(GetCorporateCasePendingReportQuery request, CancellationToken cancellationToken)
        {
            return await _repo.FetchCorporateCasePendingReportAsync(request);
        }
    }
}
