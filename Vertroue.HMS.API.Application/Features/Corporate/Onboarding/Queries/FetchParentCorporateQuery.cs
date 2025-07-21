using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Queries
{
    public record FetchParentCorporateQuery(int UserId, string UserType, string UserRole)
    : IRequest<FetchParentCorporateResponse>;
}
