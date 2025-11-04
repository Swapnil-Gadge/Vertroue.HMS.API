using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateHospital
{
    public class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public CreateHospitalCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.AddUpdateHospital(request);
        }
    }
}
