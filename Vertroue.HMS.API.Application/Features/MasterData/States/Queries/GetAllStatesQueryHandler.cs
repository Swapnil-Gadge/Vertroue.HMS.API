using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.States.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.States.Queries
{
    public class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesQuery, List<StateDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetAllStatesQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StateDto>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchStatesAsync();
        }
    }
}
