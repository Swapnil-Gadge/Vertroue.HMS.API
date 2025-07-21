using Vertroue.HMS.API.Application.Features.Corporate.Details.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.Details.Queries
{
    public class FetchCorporateDetailsResponse
    {
        public CorporateDetailsDto CorporateDetails { get; set; }
        public List<CorporateExtraDetailsDto> ExtraDetails1 { get; set; }
        public List<CorporateExtraDetailsDto> ExtraDetails2 { get; set; }
    }
}
