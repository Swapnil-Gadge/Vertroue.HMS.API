using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.List.Queries
{
    internal class FetchCorporateListHandler : IRequestHandler<FetchCorporateListQuery, FetchCorporateResponse>
    {
        private readonly ICorporateRepository _repo;

        public FetchCorporateListHandler(ICorporateRepository repo)
        {
            _repo = repo;
        }

        public async Task<FetchCorporateResponse> Handle(FetchCorporateListQuery request, CancellationToken cancellationToken)
        {
            return await _repo.FetchCorporateListAsync(request);
        }
    }
}
