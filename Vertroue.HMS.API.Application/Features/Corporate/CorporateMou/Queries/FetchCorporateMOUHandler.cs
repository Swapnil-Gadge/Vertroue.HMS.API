using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Queries
{
    public class FetchCorporateMOUHandler : IRequestHandler<FetchCorporateMOUQuery, List<CorporateMouDto>>
    {
        private readonly ICorporateRepository _repository;
        private readonly ILoggedInUserService _loggedInUserService;

        public FetchCorporateMOUHandler(ICorporateRepository repo, ILoggedInUserService loggedInUserService)
        {
            _repository = repo;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<CorporateMouDto>> Handle(FetchCorporateMOUQuery request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserLoginId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repository.FetchCorporateMOUAsync(               
                request.CorporateId,
                request.UserLoginId,
                request.UserType,
                request.UserRole);
        }
    }
}
