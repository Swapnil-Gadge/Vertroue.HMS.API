using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableEmpanelledInsuranceCompanyCommand
{
    public class DisableEmpanelledInsuranceCompanyCommand : IRequest<bool> 
    {
        public int EmpanelledInsuranceCompanyId { get; set; }
    }
}
