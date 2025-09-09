using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.Details.Queries
{
    public class FetchCorporateDetailsHandler : IRequestHandler<FetchCorporateDetailsQuery, FetchCorporateDetailsResponse>
    {
        private readonly ICorporateRepository _repo;
        private readonly ILoggedInUserService _loggedInUserService;

        public FetchCorporateDetailsHandler(ICorporateRepository repo, ILoggedInUserService loggedInUserService)
        {
            _repo = repo;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<FetchCorporateDetailsResponse> Handle(FetchCorporateDetailsQuery request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserLoginId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repo.FetchCorporateDetailsAsync(request);
        }
    }
}
