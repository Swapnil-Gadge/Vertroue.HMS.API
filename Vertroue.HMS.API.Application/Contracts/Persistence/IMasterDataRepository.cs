using Vertroue.HMS.API.Application.Features.MasterData.Models;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IMasterDataRepository
    {
        Task<List<StateDto>> GetStatesAsync();
        Task<List<ZoneDto>> GetZonesAsync();
        Task<List<CityDto>> GetCitiesAsync(int stateId);       
    }
}
