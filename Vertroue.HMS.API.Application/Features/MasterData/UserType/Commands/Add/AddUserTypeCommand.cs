using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserType.Commands.Add
{
    public class AddUserTypeCommand : IRequest<string>
    {
        public string User_Type_Name { get; set; }
        public string User_Type_Desc { get; set; }
        public int UserId { get; set; }
    }
}
