using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.UserRole.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserRole.Queries
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, List<UserRoleDto>>
    {
        private readonly IMasterDataRepository _repository;

        public GetUserRolesQueryHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserRoleDto>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchUserRoleMasterAsync();
        }
    }
}
