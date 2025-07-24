using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Commands.Deactivate
{
    public record DeactivateDocumentTypeCommand(int DocumentTypeId, int UserId) : IRequest<string>;
}
