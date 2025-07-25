using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.Zones.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.Zone.Queries
{
    public class GetAllZonesQueryHandler : IRequestHandler<GetAllZonesQuery, List<ZoneDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetAllZonesQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ZoneDto>> Handle(GetAllZonesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchZoneMasterAsync();
        }
    }
}
