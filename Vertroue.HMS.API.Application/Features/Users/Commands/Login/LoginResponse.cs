using Vertroue.HMS.API.Application.Responses;

namespace Vertroue.HMS.API.Application.Features.Users.Commands.Login
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; set; }

        public string UserName { get; set; }

        public string UserRole {  get; set; }
    }
}
