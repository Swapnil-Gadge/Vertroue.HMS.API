using Vertroue.HMS.API.Application.Features.Corporate.List.Models;

namespace Vertroue.HMS.API.Application.Features.Corporate.List.Queries
{
    public class FetchCorporateResponse
    {
        public List<CorporateListMasterDto> Corporates { get; set; }
        public List<CorporateListDetailsDto> CorporateExtras { get; set; }
    }
}
