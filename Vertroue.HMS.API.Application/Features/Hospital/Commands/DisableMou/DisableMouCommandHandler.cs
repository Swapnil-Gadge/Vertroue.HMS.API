using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableMou
{
    public class DisableMouCommandHandler : IRequestHandler<DisableMouCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public DisableMouCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(DisableMouCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.DisableMou(request.MouId);
        }
    }
}
