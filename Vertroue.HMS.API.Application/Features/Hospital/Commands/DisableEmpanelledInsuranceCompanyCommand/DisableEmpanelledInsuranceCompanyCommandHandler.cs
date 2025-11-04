using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableEmpanelledInsuranceCompanyCommand
{
    public class DisableEmpanelledInsuranceCompanyCommandHandler : IRequestHandler<DisableEmpanelledInsuranceCompanyCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public DisableEmpanelledInsuranceCompanyCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(DisableEmpanelledInsuranceCompanyCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.DisableEmpanelledInsuranceCompany(request.EmpanelledInsuranceCompanyId);
        }
    }
}
