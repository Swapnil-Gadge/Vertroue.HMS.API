using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableDoctorCommand
{
    public class DisableDoctorCommandHandler : IRequestHandler<DisableDoctorCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public DisableDoctorCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(DisableDoctorCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.DisableDoctor(request.DoctorId);
        }
    }
}
