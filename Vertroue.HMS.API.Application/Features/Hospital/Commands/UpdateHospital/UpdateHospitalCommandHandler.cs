using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateHospital
{
    public class UpdateHospitalCommandHandler : IRequestHandler<UpdateHospitalCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public UpdateHospitalCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.AddUpdateHospital(request);
        }
    }
}
