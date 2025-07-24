using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Queries
{
    internal class GetAllAdmissionTypesHandler : IRequestHandler<GetAllAdmissionTypesQuery, List<AdmissionTypeMasterDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetAllAdmissionTypesHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AdmissionTypeMasterDto>> Handle(GetAllAdmissionTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchAdmissionTypeAsync();
        }
    }
}
