using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Queries
{
    public class FetchParentCorporateResponse
    {
        public List<ParentCorporateDto> ParentCorporates { get; set; }
        public List<ParentCorporateDetailsDto> CaseDetails { get; set; }
    }
}
