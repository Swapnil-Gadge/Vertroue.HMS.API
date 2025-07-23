using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Queries.CorporateTPA
{
    public class FetchCorporateTPAHandler : IRequestHandler<FetchCorporateTPAQuery, FetchCorporateTPAResponse>
    {
        private readonly ICorporateRepository _repository;

        public FetchCorporateTPAHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<FetchCorporateTPAResponse> Handle(FetchCorporateTPAQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchCorporateTPAAsync(request);
        }
    }
}
