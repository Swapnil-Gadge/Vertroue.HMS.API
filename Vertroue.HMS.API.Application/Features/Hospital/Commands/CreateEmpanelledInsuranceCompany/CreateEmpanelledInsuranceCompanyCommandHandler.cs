using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateEmpanelledInsuranceCompany
{
    public class CreateEmpanelledInsuranceCompanyCommandHandler : IRequestHandler<CreateEmpanelledInsuranceCompanyCommand, bool>
    {
        public readonly IHospitalRepository _hospitalRepository;

        public CreateEmpanelledInsuranceCompanyCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(CreateEmpanelledInsuranceCompanyCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.AddUpdateEmpanelledInsuranceCompany(request);
        }
    }
}
