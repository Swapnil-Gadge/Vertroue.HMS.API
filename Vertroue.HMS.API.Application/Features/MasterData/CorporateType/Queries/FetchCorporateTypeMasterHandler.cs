using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Queries
{
    public class FetchCorporateTypeMasterHandler : IRequestHandler<FetchCorporateTypeMasterQuery, List<CorporateTypeMasterDto>>
    {
        private readonly IMasterDataRepository _repository;

        public FetchCorporateTypeMasterHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CorporateTypeMasterDto>> Handle(FetchCorporateTypeMasterQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchCorporateTypeAsync();
        }
    }
}
