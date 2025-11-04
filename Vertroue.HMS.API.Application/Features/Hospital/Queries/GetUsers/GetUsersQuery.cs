using MediatR;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {
        public int HospitalId { get; set; }

        public int? UserId { get; set; }
    }
}
