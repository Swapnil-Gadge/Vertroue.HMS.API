using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Queries
{
    public class GetAllIdentificationTypesQueryHandler : IRequestHandler<GetAllIdentificationTypesQuery, List<IdentificationTypeDto>>
    {
        private readonly IMasterDataRepository _repository;
        public GetAllIdentificationTypesQueryHandler(IMasterDataRepository repository) => _repository = repository;

        public async Task<List<IdentificationTypeDto>> Handle(GetAllIdentificationTypesQuery request, CancellationToken cancellationToken) =>
            await _repository.FetchIdentificationTypesAsync();
    }
}