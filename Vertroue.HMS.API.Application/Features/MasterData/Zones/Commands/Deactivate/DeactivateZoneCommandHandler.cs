using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.Zone.Commands.Deactivate
{
    public class DeactivateZoneCommandHandler : IRequestHandler<DeactivateZoneCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateZoneCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateZoneCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageZoneMasterAsync(request, 'D');
        }
    }
}