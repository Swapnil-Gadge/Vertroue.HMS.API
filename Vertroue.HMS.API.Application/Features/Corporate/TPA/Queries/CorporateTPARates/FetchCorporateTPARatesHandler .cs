using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Queries.CorporateTPARates
{
    public class FetchCorporateTPARatesHandler : IRequestHandler<FetchCorporateTPARatesQuery, List<CorporateTPARateDto>>
    {
        private readonly ICorporateRepository _repository;

        public FetchCorporateTPARatesHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CorporateTPARateDto>> Handle(FetchCorporateTPARatesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchCorporateTPARatesAsync(request);
        }
    }
}
