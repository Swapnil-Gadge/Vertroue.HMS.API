using Vertroue.HMS.API.Application.Features.Corporate.TPA.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Queries.CorporateTPA
{
    public class FetchCorporateTPAResponse
    {
        public List<CorporateTPADetailsDto> CorporateTPAs { get; set; } = new();
        public List<TPAMasterDto> TPAMasterList { get; set; } = new();
    }
}
