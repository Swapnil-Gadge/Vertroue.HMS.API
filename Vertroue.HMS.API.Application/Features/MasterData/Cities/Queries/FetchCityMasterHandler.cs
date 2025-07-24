using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.Cities.Models;

namespace Vertroue.HMS.API.Application.Features.MasterData.Cities.Queries;

public class FetchCityMasterHandler : IRequestHandler<FetchCityMasterQuery, List<CityMasterDto>>
{
    private readonly IMasterDataRepository _repository;

    public FetchCityMasterHandler(IMasterDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CityMasterDto>> Handle(FetchCityMasterQuery request, CancellationToken cancellationToken)
    {
        return await _repository.FetchCitiesAsync();
    }
}