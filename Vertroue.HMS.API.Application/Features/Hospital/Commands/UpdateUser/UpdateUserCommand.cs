using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }

        public int HospitalId { get; set; }

        public string Name { get; set; } = null!;

        public int UserRoleId { get; set; }

        public string Email { get; set; } = null!;

        public string UserLoginId { get; set; } = null!;

        public string? Password { get; set; }

        public string ContactNumber { get; set; }
    }
}
