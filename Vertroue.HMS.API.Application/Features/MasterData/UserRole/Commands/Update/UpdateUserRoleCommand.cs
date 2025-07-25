using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserRole.Commands.Update
{
    public class UpdateUserRoleCommand : IRequest<string>
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public int UserId { get; set; }
    }
}
