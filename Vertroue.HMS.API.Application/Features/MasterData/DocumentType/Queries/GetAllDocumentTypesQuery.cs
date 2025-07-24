using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Queries
{
    public record GetAllDocumentTypesQuery : IRequest<List<DocumentTypeDto>>;
}
