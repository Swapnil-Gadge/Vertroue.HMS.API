using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Deactivate
{
    public class DeactivateStatusMasterCommand : IRequest<string>
    {
        public int Status_Id { get; set; }
        public int UserId { get; set; }
    }
}
