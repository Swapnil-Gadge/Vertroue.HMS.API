using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserRole.Commands.Add
{
    public class AddUserRoleCommand : IRequest<string>
    {
        public string UserRoleName { get; set; }
        public int UserId { get; set; }
    }
}
