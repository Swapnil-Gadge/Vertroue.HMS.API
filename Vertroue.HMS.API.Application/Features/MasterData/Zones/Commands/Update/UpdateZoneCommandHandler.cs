using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.Zone.Commands.Update
{
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateZoneCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageZoneMasterAsync(request, 'U');
        }
    }
}