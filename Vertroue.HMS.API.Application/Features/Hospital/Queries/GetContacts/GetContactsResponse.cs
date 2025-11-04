using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetContacts
{
    public class GetContactsResponse
    {
        public List<ContactDto> Contacts { get; set; } = new List<ContactDto>();

        public List<EmpanelledInsuranceCompanyDto> InsuranceCompanies { get; set; }

        public List<EmpanelledTpaDto> Tpas { get; set; }
    }
}
