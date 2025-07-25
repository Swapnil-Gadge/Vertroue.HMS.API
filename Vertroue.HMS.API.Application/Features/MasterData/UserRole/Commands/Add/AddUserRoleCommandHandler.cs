using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserRole.Commands.Add
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddUserRoleCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageUserRoleMasterAsync(request, 'I');
        }
    }
}
