using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Model;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Queries
{
    public class GetAllInsurersQueryHandler : IRequestHandler<GetAllInsurersQuery, List<InsurerDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetAllInsurersQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<InsurerDto>> Handle(GetAllInsurersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchInsurersAsync();
        }
    }
}
