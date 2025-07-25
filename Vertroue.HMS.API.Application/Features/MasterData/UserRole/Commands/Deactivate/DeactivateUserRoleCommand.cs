using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserRole.Commands.Deactivate
{
    public class DeactivateUserRoleCommand : IRequest<string>
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
    }
}
