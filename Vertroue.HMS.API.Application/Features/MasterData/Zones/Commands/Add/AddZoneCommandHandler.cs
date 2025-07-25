using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
namespace Vertroue.HMS.API.Application.Features.MasterData.Zone.Commands.Add
{
    public class AddZoneCommandHandler : IRequestHandler<AddZoneCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddZoneCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddZoneCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageZoneMasterAsync(request, 'I');
        }
    }
}