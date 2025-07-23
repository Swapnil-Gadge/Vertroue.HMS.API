using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurerRates.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurerRates.Queries
{
    public class FetchCorporateInsurerRatesQueryHandler : IRequestHandler<FetchCorporateInsurerRatesQuery, List<CorporateInsurerRateDto>>
    {
        private readonly ICorporateRepository _repository;

        public FetchCorporateInsurerRatesQueryHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CorporateInsurerRateDto>> Handle(FetchCorporateInsurerRatesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchCorporateInsurerRatesAsync(
                request.CorporateInsurerId,
                request.CorporateId,
                request.UserId,
                request.UserType,
                request.UserRole);
        }
    }
}
