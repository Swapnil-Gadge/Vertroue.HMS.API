using Vertroue.HMS.API.Application.Features.MasterData.Models;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    internal class MasterDataRepository : IMasterDataRepository
    {
        public async Task<List<StateDto>> GetStatesAsync() => new List<StateDto> {
        new StateDto { StateId = 1, StateName = "Maharashtra" },
        new StateDto { StateId = 2, StateName = "Gujarat" }
    };

        public async Task<List<ZoneDto>> GetZonesAsync() => new List<ZoneDto> {
        new ZoneDto { ZoneId = 1, ZoneName = "West Zone" },
        new ZoneDto { ZoneId = 2, ZoneName = "North Zone" }
    };

        public async Task<List<CityDto>> GetCitiesAsync(int stateId)
        {
            var cities = new List<CityDto> {
            new CityDto { CityId = 1, CityName = "Mumbai", StateId = 1 },
            new CityDto { CityId = 2, CityName = "Pune", StateId = 1 },
            new CityDto { CityId = 3, CityName = "Ahmedabad", StateId = 2 }
        };

            return cities.Where(c => c.StateId == stateId).ToList();
        }
    }
}
