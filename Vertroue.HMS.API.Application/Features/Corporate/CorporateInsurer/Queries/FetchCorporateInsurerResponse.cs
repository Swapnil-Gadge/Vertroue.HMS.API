using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Queries
{
    public class FetchCorporateInsurerResponse
    {
        public List<CorporateInsurerDto> CorporateInsurers { get; set; } = new();
        public List<InsurerMasterDto> InsurerMasterList { get; set; } = new();
    }
}
