using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.List.Queries
{
    public record FetchCorporateListQuery(int ParentCorporateId, int UserId, string UserType, string UserRole)
        : IRequest<FetchCorporateResponse>;
}
