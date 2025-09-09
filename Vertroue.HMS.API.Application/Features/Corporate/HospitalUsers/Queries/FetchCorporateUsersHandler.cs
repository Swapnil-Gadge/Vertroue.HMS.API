using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Queries
{
    public class FetchCorporateUsersHandler : IRequestHandler<FetchCorporateUsersQuery, List<CorporateUserDto>>
    {
        private readonly ICorporateRepository _repo;
        private readonly ILoggedInUserService _loggedInUserService;

        public FetchCorporateUsersHandler(ICorporateRepository repo, ILoggedInUserService loggedInUserService)
        {
            _repo = repo;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<CorporateUserDto>> Handle(FetchCorporateUsersQuery request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repo.FetchCorporateUsersAsync(request);
        }
    }
}
