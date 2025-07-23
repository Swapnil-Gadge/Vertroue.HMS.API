using MediatR;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurerRates.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurerRates.Queries
{
    public record FetchCorporateInsurerRatesQuery(
    int CorporateInsurerId,
    int CorporateId,
    int UserId,
    string UserType,
    string UserRole
) : IRequest<List<CorporateInsurerRateDto>>;
}
