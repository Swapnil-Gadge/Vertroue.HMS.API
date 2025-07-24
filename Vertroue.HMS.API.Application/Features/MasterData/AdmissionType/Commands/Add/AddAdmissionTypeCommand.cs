using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Commands.Add
{
    public record AddAdmissionTypeCommand(string AdmissionTypeName, int UserId) : IRequest<string>;
}