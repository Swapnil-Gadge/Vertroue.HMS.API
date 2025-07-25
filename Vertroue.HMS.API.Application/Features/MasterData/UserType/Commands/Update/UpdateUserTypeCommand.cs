using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserType.Commands.Update
{
    public class UpdateUserTypeCommand : IRequest<string>
    {
        public int User_Type_id { get; set; }
        public string User_Type_Name { get; set; }
        public string User_Type_Desc { get; set; }
        public int UserId { get; set; }
    }
}
