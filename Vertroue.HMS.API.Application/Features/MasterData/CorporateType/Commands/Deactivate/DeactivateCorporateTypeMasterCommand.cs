using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Commands.Deactivate
{
    public record DeactivateCorporateTypeMasterCommand(
        int CorporateTypeId,
        int UserId
    ) : IRequest<string>;
}