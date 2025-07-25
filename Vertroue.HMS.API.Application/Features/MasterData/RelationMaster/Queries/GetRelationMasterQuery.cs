using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Queries
{
    public class GetRelationMasterQuery : IRequest<List<RelationMasterDto>> { }
}
