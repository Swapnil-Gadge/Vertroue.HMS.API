using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Update
{
    public class UpdateStatusMasterCommand : IRequest<string>
    {
        public int Status_Id { get; set; }
        public string Status_Name { get; set; }
        public string Status_Desc { get; set; }
        public string Status_Action_Owner { get; set; }
        public string Status_Post_Action_Owner { get; set; }
        public int UserId { get; set; }
    }
}
