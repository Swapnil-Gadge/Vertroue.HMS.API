using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Queries
{
    public class GetRelationMasterQueryHandler : IRequestHandler<GetRelationMasterQuery, List<RelationMasterDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetRelationMasterQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RelationMasterDto>> Handle(GetRelationMasterQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchRelationMasterAsync();
        }
    }
}
