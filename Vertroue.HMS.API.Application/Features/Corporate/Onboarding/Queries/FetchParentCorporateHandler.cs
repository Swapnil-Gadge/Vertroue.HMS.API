using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Queries
{
    internal class FetchParentCorporateHandler : IRequestHandler<FetchParentCorporateQuery, FetchParentCorporateResponse>
    {
        private readonly ICorporateRepository _repo;

        public FetchParentCorporateHandler(ICorporateRepository repo)
        {
            _repo = repo;
        }

        public async Task<FetchParentCorporateResponse> Handle(FetchParentCorporateQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetParentCorporateWithDetailsAsync(request.UserId, request.UserType, request.UserRole);
        }
    }
}
