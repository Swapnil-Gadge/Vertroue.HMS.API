using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateEmapnelledTPACommand
{
    public class CreateEmapnelledTPACommandHandler : IRequestHandler<CreateEmapnelledTPACommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public CreateEmapnelledTPACommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(CreateEmapnelledTPACommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.AddUpdateEmpanelledTpa(request);
        }
    }
}
