using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateDoctorCommand
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public UpdateDoctorCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.AddUpdateDoctor(request);
        }
    }
}
