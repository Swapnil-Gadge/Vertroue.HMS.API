using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Commands.Deactivate
{
    public class DeactivateRelationMasterCommand : IRequest<string>
    {
        public int RelationId { get; set; }
        public int UserId { get; set; }
    }
}
