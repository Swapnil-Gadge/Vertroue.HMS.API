using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Queries
{
    public record GetAllAdmissionTypesQuery : IRequest<List<AdmissionTypeMasterDto>>;
}