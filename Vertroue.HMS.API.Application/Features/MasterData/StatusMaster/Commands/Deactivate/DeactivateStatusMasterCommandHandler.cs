using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Deactivate
{
    public class DeactivateStatusMasterCommandHandler : IRequestHandler<DeactivateStatusMasterCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateStatusMasterCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateStatusMasterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageStatusMasterAsync(request, 'D');
        }
    }
}
