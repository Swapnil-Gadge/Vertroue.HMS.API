using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Commands.Add
{
    public class AddStatusProcessFlowCommandHandler : IRequestHandler<AddStatusProcessFlowCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddStatusProcessFlowCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddStatusProcessFlowCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageStatusProcessFlowAsync(request, 'I');
        }
    }
}
