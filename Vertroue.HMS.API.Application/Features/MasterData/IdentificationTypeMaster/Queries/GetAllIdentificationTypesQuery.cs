using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Queries
{
    public class GetAllIdentificationTypesQuery : IRequest<List<IdentificationTypeDto>> { }
}