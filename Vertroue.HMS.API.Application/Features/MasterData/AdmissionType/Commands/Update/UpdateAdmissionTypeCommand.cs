using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Commands.Update
{
    public record UpdateAdmissionTypeCommand(int AdmissionTypeId, string AdmissionTypeName, int UserId) : IRequest<string>;
}