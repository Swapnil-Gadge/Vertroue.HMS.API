using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateEmapnelledTPACommand
{
    public class UpdateEmapnelledTPACommandHandler : IRequestHandler<UpdateEmapnelledTPACommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public UpdateEmapnelledTPACommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(UpdateEmapnelledTPACommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.AddUpdateEmpanelledTpa(request);
        }
    }
}
