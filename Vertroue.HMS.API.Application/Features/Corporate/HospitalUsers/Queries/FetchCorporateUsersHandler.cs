using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Queries
{
    public class FetchCorporateUsersHandler : IRequestHandler<FetchCorporateUsersQuery, List<CorporateUserDto>>
    {
        private readonly ICorporateRepository _repo;

        public FetchCorporateUsersHandler(ICorporateRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CorporateUserDto>> Handle(FetchCorporateUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repo.FetchCorporateUsersAsync(request);
        }
    }
}
