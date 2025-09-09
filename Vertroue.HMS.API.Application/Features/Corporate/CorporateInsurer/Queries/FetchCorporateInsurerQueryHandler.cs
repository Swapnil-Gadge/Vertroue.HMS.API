using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Queries
{
    public class FetchCorporateInsurerQueryHandler : IRequestHandler<FetchCorporateInsurerQuery, FetchCorporateInsurerResponse>
    {
        private readonly ICorporateRepository _repo;
        private readonly ILoggedInUserService _loggedInUserService;

        public FetchCorporateInsurerQueryHandler(ICorporateRepository repo, ILoggedInUserService loggedInUserService)
        {
            _repo = repo;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<FetchCorporateInsurerResponse> Handle(FetchCorporateInsurerQuery request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserLoginId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repo.FetchCorporateInsurersAsync(request.CorporateId, request.UserLoginId, request.UserType, request.UserRole);
        }
    }
}
