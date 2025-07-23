using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Queries
{
    public class FetchCorporateRenewalsHandler : IRequestHandler<FetchCorporateRenewalsQuery, FetchCorporateRenewalsResponse>
    {
        private readonly ICorporateRepository _repository;

        public FetchCorporateRenewalsHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<FetchCorporateRenewalsResponse> Handle(FetchCorporateRenewalsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchCorporateRenewalsAsync(request.CorporateId, request.UserId, request.UserType, request.UserRole);
        }
    }
}
