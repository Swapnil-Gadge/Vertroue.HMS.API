using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Commands
{
    public class UpdateIdentificationTypeCommandHandler : IRequestHandler<UpdateIdentificationTypeCommand, string>
    {
        private readonly IMasterDataRepository _repository;
        public UpdateIdentificationTypeCommandHandler(IMasterDataRepository repository) => _repository = repository;

        public async Task<string> Handle(UpdateIdentificationTypeCommand request, CancellationToken cancellationToken) =>
            await _repository.ManageIdentificationTypeAsync(request, 'U');
    }
}
