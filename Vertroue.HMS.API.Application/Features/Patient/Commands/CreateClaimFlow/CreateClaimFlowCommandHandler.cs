using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Models.Patient;
using AutoMapper;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlow
{
    public class CreateClaimFlowCommandHandler : IRequestHandler<CreateClaimFlowCommand, ClaimFlowDto>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public CreateClaimFlowCommandHandler(IMapper mapper,
            IPatientRepository patientRepository, 
            ILoggedInUserService loggedInUserService)
        {
            _loggedInUserService = loggedInUserService;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<ClaimFlowDto> Handle(CreateClaimFlowCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("User is not authorized to perform this operation.");

            var claimFlow = _mapper.Map<ClaimFlow>(request);
            var result = await _patientRepository.AddClaimFlowAsync(claimFlow);
            await _patientRepository.UpdateClaimFlowDocs(request.ClaimFlowDocIds, claimFlow.ClaimFlowId);
            var claimflow = _mapper.Map<ClaimFlowDto>(result);
            var claimflowDocs = await _patientRepository.GetClaimFlowDocsByClaimFlowIdAsync(claimflow.ClaimFlowId);
            claimflow.ClaimFlowDocs = _mapper.Map<List<ClaimFlowDocDto>>(claimflowDocs);
            return claimflow;
        }
    }
}
