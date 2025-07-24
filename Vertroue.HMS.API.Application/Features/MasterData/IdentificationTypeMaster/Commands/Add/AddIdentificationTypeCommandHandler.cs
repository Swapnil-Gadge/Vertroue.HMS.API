using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Commands
{
    public class AddIdentificationTypeCommandHandler : IRequestHandler<AddIdentificationTypeCommand, string>
    {
        private readonly IMasterDataRepository _repository;
        public AddIdentificationTypeCommandHandler(IMasterDataRepository repository) => _repository = repository;

        public async Task<string> Handle(AddIdentificationTypeCommand request, CancellationToken cancellationToken) =>
            await _repository.ManageIdentificationTypeAsync(request, 'I');
    }
}