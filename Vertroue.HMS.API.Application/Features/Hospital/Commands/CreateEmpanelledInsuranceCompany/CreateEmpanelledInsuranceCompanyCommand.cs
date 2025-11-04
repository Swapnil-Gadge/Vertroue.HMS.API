using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateEmpanelledInsuranceCompany
{
    public class CreateEmpanelledInsuranceCompanyCommand : IRequest<bool>
    {
        public int? InsuranceCompanyId { get; set; }

        public string Portal { get; set; } = null!;

        public string? UserName { get; set; }

        public string? PassWord { get; set; }

        public int? HospitalId { get; set; }

        public DateTime? EmpanelledDate { get; set; }
    }
}
