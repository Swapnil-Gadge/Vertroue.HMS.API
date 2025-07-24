using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Commands.Update
{
    public record UpdateDocumentTypeCommand(
        int DocumentTypeId,
        string DocumentTypeName,
        string DocumentDesc,
        string DocumentOwner,
        int UserId
    ) : IRequest<string>;
}
