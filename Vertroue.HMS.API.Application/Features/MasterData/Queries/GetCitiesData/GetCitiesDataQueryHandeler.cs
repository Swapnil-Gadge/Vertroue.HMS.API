using MediatR;
using System;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.Models;

namespace Vertroue.HMS.API.Application.Features.MasterData.Queries.GetMasterData
{
    public class GetCitiesDataQueryHandeler : IRequestHandler<FetchCitiesQuery, List<CityDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetCitiesDataQueryHandeler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CityDto>> Handle(FetchCitiesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCitiesAsync(request.StateId);
        }
    }
}
