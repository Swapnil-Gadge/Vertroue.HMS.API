using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Commands.Update
{
    public record UpdateCorporateTypeMasterCommand(
        int CorporateTypeId,
        string CorporateTypeName,
        string CorporateTypeDescription,
        int UserId
    ) : IRequest<string>;
}