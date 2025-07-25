using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.UserRole.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserRole.Queries
{
    public class GetUserRolesQuery : IRequest<List<UserRoleDto>>
    {
    }
}
