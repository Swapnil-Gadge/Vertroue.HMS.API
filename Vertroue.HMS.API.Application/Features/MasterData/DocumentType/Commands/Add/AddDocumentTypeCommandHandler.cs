using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Commands.Add
{
    public class AddDocumentTypeCommandHandler : IRequestHandler<AddDocumentTypeCommand, string>
    {
        private readonly IMasterDataRepository _repo;

        public AddDocumentTypeCommandHandler(IMasterDataRepository repo) => _repo = repo;

        public async Task<string> Handle(AddDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ManageDocumentTypeAsync(null, request.DocumentTypeName, request.DocumentDesc, request.DocumentOwner, request.UserId, "I");
        }
    }
}
