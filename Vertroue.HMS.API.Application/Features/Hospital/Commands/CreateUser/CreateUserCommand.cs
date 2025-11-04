using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        public int HospitalId { get; set; }

        public string Name { get; set; } = null!;

        public int UserRoleId { get; set; }

        public string Email { get; set; } = null!;

        public string UserLoginId { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string ContactNumber { get; set; }
    }
}
