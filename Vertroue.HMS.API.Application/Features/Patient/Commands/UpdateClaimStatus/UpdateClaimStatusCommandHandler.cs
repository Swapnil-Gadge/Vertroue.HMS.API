using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.UpdateClaimStatus
{
    public class UpdateClaimStatusCommandHandler : IRequestHandler<UpdateClaimStatusCommand, bool>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public UpdateClaimStatusCommandHandler(IPatientRepository patientRepository,
            ILoggedInUserService loggedInUserService)
        {
            _patientRepository = patientRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<bool> Handle(UpdateClaimStatusCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("User is not authorized to perform this operation.");

            try
            {
                return await _patientRepository.UpdateClaimStatus(request.PatientId, request.Status);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.InnerException?.Message ?? ex.Message);
            }            
        }
    }
}
