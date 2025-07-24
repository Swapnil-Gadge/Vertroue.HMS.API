using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Queries
{
    public class GetAllCorporatePlansQueryHandler : IRequestHandler<GetAllCorporatePlansQuery, List<CorporatePlanDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetAllCorporatePlansQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CorporatePlanDto>> Handle(GetAllCorporatePlansQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchCorporatePlansAsync();
        }
    }
}