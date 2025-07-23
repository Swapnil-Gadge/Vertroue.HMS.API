using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Queries
{
    public class FetchCorporateInsurerQueryHandler : IRequestHandler<FetchCorporateInsurerQuery, FetchCorporateInsurerResponse>
    {
        private readonly ICorporateRepository _repo;

        public FetchCorporateInsurerQueryHandler(ICorporateRepository repo)
        {
            _repo = repo;
        }

        public async Task<FetchCorporateInsurerResponse> Handle(FetchCorporateInsurerQuery request, CancellationToken cancellationToken)
        {
            return await _repo.FetchCorporateInsurersAsync(request.CorporateId, request.UserId, request.UserType, request.UserRole);
        }
    }
}
