using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Commands.Deactivate
{
    public record DeactivateAdmissionTypeCommand(int AdmissionTypeId, int UserId) : IRequest<string>;
}