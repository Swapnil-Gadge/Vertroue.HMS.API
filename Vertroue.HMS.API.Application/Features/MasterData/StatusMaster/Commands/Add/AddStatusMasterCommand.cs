using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Add
{
    public class AddStatusMasterCommand : IRequest<string>
    {
        public string Status_Name { get; set; }
        public string Status_Desc { get; set; }
        public string Status_Action_Owner { get; set; }
        public string Status_Post_Action_Owner { get; set; }
        public int UserId { get; set; }
    }
}