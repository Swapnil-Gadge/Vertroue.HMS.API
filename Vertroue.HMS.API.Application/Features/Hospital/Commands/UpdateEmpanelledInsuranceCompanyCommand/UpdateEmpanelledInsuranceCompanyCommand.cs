using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateEmpanelledInsuranceCompanyCommand
{
    public class UpdateEmpanelledInsuranceCompanyCommand : IRequest<bool>
    {
        public int EmpanelledInsCompId { get; set; }

        public int? InsuranceCompanyId { get; set; }

        public string Portal { get; set; } = null!;

        public string? UserName { get; set; }

        public string? PassWord { get; set; }

        public DateTime? EmpanelledDate { get; set; }
    }
}
