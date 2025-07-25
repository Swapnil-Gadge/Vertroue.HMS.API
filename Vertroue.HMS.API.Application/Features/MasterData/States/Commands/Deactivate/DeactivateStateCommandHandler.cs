using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.States.Commands.Deactivate
{
    public class DeactivateStateCommandHandler : IRequestHandler<DeactivateStateCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateStateCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateStateCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageStateMasterAsync(request, 'D');
        }
    }
}
