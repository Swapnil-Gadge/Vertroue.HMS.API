using MediatR;
using System;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.Models;

namespace Vertroue.HMS.API.Application.Features.MasterData.Queries.GetMasterData
{
    public class GetStatesDataQueryHandeler : IRequestHandler<FetchStatesQuery, List<StateDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetStatesDataQueryHandeler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StateDto>> Handle(FetchStatesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetStatesAsync();
        }
    }
}
