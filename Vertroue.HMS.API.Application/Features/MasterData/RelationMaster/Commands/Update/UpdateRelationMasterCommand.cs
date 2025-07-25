using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Commands.Update
{
    public class UpdateRelationMasterCommand : IRequest<string>
    {
        public int RelationId { get; set; }
        public string RelationCode { get; set; }
        public string RelationName { get; set; }
        public int UserId { get; set; }
    }
}
