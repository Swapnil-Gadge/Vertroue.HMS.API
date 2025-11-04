using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateDoctorCommand
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public CreateDoctorCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.AddUpdateDoctor(request);
        }
    }
}
