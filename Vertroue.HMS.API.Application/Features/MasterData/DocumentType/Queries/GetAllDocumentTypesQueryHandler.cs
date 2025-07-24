using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Queries
{
    public class GetAllDocumentTypesQueryHandler : IRequestHandler<GetAllDocumentTypesQuery, List<DocumentTypeDto>>
    {
        private readonly IMasterDataRepository _repo;

        public GetAllDocumentTypesQueryHandler(IMasterDataRepository repo) => _repo = repo;

        public async Task<List<DocumentTypeDto>> Handle(GetAllDocumentTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.FetchDocumentTypesAsync();
        }
    }
}
