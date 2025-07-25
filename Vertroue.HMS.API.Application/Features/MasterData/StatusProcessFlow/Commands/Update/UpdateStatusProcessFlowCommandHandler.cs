using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Commands.Update
{
    public class UpdateStatusProcessFlowCommandHandler : IRequestHandler<UpdateStatusProcessFlowCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateStatusProcessFlowCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateStatusProcessFlowCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageStatusProcessFlowAsync(request, 'U');
        }
    }
}
