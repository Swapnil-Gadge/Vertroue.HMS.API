using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserRole.Commands.Update
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateUserRoleCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageUserRoleMasterAsync(request, 'U');
        }
    }
}
