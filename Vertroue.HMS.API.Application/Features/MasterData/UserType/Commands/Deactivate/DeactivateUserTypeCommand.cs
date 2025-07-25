using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserType.Commands.Deactivate
{
    public class DeactivateUserTypeCommand : IRequest<string>
    {
        public int User_Type_id { get; set; }
        public int UserId { get; set; }
    }
}
