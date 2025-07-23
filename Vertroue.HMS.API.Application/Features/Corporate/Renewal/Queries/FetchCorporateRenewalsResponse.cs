using Vertroue.HMS.API.Application.Features.Corporate.Renewal.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Queries
{
    public class FetchCorporateRenewalsResponse
    {
        public List<CorporateRenewalDto> Renewals { get; set; } = new();
        public List<CorporateRenewalDetailsDto> RenewalDetails { get; set; } = new();
    }
}
