using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Queries
{
    public class FetchCorporateRenewalsHandler : IRequestHandler<FetchCorporateRenewalsQuery, FetchCorporateRenewalsResponse>
    {
        private readonly ICorporateRepository _repository;
        private readonly ILoggedInUserService _loggedInUserService;

        public FetchCorporateRenewalsHandler(ICorporateRepository repository, ILoggedInUserService loggedInUserService)
        {
            _repository = repository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<FetchCorporateRenewalsResponse> Handle(FetchCorporateRenewalsQuery request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserLoginId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repository.FetchCorporateRenewalsAsync(request.CorporateId, request.UserLoginId, request.UserType, request.UserRole);
        }
    }
}
