using MediatR;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Queries
{
    public record FetchCorporateUsersQuery(int CorporateId, int UserId, string UserType, string UserRole)
        : IRequest<List<CorporateUserDto>>;
}
