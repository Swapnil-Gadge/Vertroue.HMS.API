using MediatR;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.Details.Queries
{
    public record FetchCorporateDetailsQuery(int ParentCorporateId, int CorporateId, int UserId, string UserType, string UserRole)
    : IRequest<FetchCorporateDetailsResponse>;
}
