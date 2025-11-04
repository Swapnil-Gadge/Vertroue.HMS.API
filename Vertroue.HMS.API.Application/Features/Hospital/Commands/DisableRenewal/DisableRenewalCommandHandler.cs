using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableRenewal
{
    public class DisableRenewalCommandHandler : IRequestHandler<DisableRenewalCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public DisableRenewalCommandHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<bool> Handle(DisableRenewalCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("User is not authorized to perform this operation.");

            return await _hospitalRepository.DisableRenewal(request.RenewalId);
        }
    }
}
