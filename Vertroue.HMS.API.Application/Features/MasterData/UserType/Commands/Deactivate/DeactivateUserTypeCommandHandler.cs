using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserType.Commands.Deactivate
{
    public class DeactivateUserTypeCommandHandler : IRequestHandler<DeactivateUserTypeCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateUserTypeCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateUserTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageUserTypeAsync(request, 'D');
        }
    }
}
