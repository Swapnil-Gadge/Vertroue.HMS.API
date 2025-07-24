using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Commands.Update
{
    public class UpdateDocumentTypeCommandHandler : IRequestHandler<UpdateDocumentTypeCommand, string>
    {
        private readonly IMasterDataRepository _repo;

        public UpdateDocumentTypeCommandHandler(IMasterDataRepository repo) => _repo = repo;

        public async Task<string> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ManageDocumentTypeAsync(request.DocumentTypeId, request.DocumentTypeName, request.DocumentDesc, request.DocumentOwner, request.UserId, "U");
        }
    }
}
