using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Queries
{
    public class GetAllStatusMasterQueryHandler : IRequestHandler<GetAllStatusMasterQuery, List<StatusMasterDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetAllStatusMasterQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StatusMasterDto>> Handle(GetAllStatusMasterQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchStatusMasterAsync(request.UserId);
        }
    }
}
