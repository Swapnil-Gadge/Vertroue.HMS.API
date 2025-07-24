using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Commands.Add
{
    public record AddDocumentTypeCommand(
        string DocumentTypeName,
        string DocumentDesc,
        string DocumentOwner,
        int UserId
    ) : IRequest<string>;
}
