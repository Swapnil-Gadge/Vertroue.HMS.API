using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateEmpanelledInsuranceCompanyCommand
{
    public class UpdateEmpanelledInsuranceCompanyCommandHandler : IRequestHandler<UpdateEmpanelledInsuranceCompanyCommand, bool>
    {
        private IHospitalRepository _hospitalRepository;

        public UpdateEmpanelledInsuranceCompanyCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(UpdateEmpanelledInsuranceCompanyCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.AddUpdateEmpanelledInsuranceCompany(request);
        }
    }
}
