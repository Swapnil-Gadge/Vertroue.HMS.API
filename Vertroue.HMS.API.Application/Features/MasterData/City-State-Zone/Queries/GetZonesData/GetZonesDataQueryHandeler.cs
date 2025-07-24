using MediatR;
using System;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.Models;

namespace Vertroue.HMS.API.Application.Features.MasterData.Queries.GetMasterData
{
    public class GetZonesDataQueryHandeler : IRequestHandler<FetchZonesQuery, List<ZoneDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetZonesDataQueryHandeler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ZoneDto>> Handle(FetchZonesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetZonesAsync();
        }
    }
}
