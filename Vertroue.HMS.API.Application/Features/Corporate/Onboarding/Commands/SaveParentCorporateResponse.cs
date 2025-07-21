using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Commands
{
    public class SaveParentCorporateResponse
    {
        public string Message { get; set; }
        public List<ParentCorporateDto> ParentCorporateList { get; set; }
        public List<ParentCorporateDetailsDto> CaseDetails { get; set; }
    }
}
