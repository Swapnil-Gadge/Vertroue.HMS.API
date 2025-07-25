using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Model;
namespace Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Queries
{
    public class GetStatusProcessFlowQueryHandler : IRequestHandler<GetStatusProcessFlowQuery, List<StatusProcessFlowDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetStatusProcessFlowQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StatusProcessFlowDto>> Handle(GetStatusProcessFlowQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchStatusProcessFlowAsync();
        }
    }
}
