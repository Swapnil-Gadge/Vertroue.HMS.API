using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Commands.Deactivate
{
    public class DeactivateDocumentTypeCommandHandler : IRequestHandler<DeactivateDocumentTypeCommand, string>
    {
        private readonly IMasterDataRepository _repo;

        public DeactivateDocumentTypeCommandHandler(IMasterDataRepository repo) => _repo = repo;

        public async Task<string> Handle(DeactivateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ManageDocumentTypeAsync(request.DocumentTypeId, null, null, null, request.UserId, "D");
        }
    }
}
