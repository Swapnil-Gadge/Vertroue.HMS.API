using MediatR;
using Vertroue.HMS.API.Application.Features.Users.Model;

namespace Vertroue.HMS.API.Application.Features.Users.Queries.ValidateLogin
{
    public class ValidateLoginQuery : IRequest<LoginResponseDto>
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
