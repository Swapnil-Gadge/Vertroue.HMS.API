using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Commands
{
    public class DeactivateIdentificationTypeCommandHandler : IRequestHandler<DeactivateIdentificationTypeCommand, string>
    {
        private readonly IMasterDataRepository _repository;
        public DeactivateIdentificationTypeCommandHandler(IMasterDataRepository repository) => _repository = repository;

        public async Task<string> Handle(DeactivateIdentificationTypeCommand request, CancellationToken cancellationToken) =>
            await _repository.ManageIdentificationTypeAsync(request, 'D');
    }
}