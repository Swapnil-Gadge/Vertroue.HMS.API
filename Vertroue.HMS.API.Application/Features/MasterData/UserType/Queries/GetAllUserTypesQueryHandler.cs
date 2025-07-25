using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.UserType.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserType.Queries
{
    public class GetAllUserTypesQueryHandler : IRequestHandler<GetAllUserTypesQuery, List<UserTypeDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetAllUserTypesQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserTypeDto>> Handle(GetAllUserTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchUserTypeAsync();
        }
    }
}
