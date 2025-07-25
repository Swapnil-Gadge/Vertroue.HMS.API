using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserRole.Commands.Deactivate
{
    public class DeactivateUserRoleCommandHandler : IRequestHandler<DeactivateUserRoleCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateUserRoleCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageUserRoleMasterAsync(request, 'D');
        }
    }
}
