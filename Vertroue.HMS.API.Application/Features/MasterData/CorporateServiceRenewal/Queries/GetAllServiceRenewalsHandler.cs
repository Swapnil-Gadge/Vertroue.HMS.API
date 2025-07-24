using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Queries
{
    public class GetAllServiceRenewalsQueryHandler : IRequestHandler<GetAllServiceRenewalsQuery, List<CorporateServiceRenewalDto>>
    {
        private readonly IMasterDataRepository _repo;

        public GetAllServiceRenewalsQueryHandler(IMasterDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CorporateServiceRenewalDto>> Handle(GetAllServiceRenewalsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.FetchServiceRenewalsAsync();
        }
    }
}
