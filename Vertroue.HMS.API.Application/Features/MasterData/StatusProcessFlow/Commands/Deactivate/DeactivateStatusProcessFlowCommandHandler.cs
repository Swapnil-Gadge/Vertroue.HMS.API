using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Commands.Deactivate
{
    public class DeactivateStatusProcessFlowCommandHandler : IRequestHandler<DeactivateStatusProcessFlowCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateStatusProcessFlowCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateStatusProcessFlowCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageStatusProcessFlowAsync(request, 'D');
        }
    }
}
