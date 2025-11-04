using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetMous
{
    public class GetMousQueryResponse
    {
        public List<MouDto> Mous { get; set; } = new List<MouDto>();

        public List<EmpanelledInsuranceCompanyDto> InsuranceCompanies { get; set; }

        public List<EmpanelledTpaDto> Tpas { get; set; }
    }
}
