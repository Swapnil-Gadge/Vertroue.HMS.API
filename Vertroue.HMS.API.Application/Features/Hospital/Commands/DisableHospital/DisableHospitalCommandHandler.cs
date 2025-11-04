using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableHospital
{
    public class DisableHospitalCommandHandler : IRequestHandler<DisableHospitalCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public DisableHospitalCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(DisableHospitalCommand request, CancellationToken cancellationToken)
        {
            await _hospitalRepository.DisableEntity(request.HospitalId);
            return false;
        }
    }
}
