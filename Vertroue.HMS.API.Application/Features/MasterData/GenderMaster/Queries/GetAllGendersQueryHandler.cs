using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Queries
{
    public class GetAllGendersQueryHandler : IRequestHandler<GetAllGendersQuery, List<GenderDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetAllGendersQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GenderDto>> Handle(GetAllGendersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchGendersAsync();
        }
    }
}