using MediatR;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetEmpanelledInsuranceCompanyQuery
{
    public class GetEmpanelledInsuranceCompanyQuery : IRequest<List<EmpanelledInsuranceCompanyDto>>
    {
        public int HospitalId { get; set; }

        public int? EmpanelledInsuranceCompanyId { get; set; }
    }
}
