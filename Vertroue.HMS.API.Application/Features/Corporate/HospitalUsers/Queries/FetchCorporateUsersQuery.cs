using MediatR;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Queries
{
    public class FetchCorporateUsersQuery : IRequest<List<CorporateUserDto>>
    {
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
