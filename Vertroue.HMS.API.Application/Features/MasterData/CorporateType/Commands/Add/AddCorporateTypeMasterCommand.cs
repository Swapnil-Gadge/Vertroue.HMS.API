using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Commands.Add
{
    public record AddCorporateTypeMasterCommand(
        string CorporateTypeName,
        string CorporateTypeDescription,
        int UserId
    ) : IRequest<string>;
}