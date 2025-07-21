using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.Details.Queries
{
    public class FetchCorporateDetailsHandler : IRequestHandler<FetchCorporateDetailsQuery, FetchCorporateDetailsResponse>
    {
        private readonly ICorporateRepository _repo;

        public FetchCorporateDetailsHandler(ICorporateRepository repo)
        {
            _repo = repo;
        }

        public async Task<FetchCorporateDetailsResponse> Handle(FetchCorporateDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.FetchCorporateDetailsAsync(request);
        }
    }
}
