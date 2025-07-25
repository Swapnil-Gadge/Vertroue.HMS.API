using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Commands.Add
{
    public class AddRelationMasterCommand : IRequest<string>
    {
        public string RelationCode { get; set; }
        public string RelationName { get; set; }
        public int UserId { get; set; }
    }
}
