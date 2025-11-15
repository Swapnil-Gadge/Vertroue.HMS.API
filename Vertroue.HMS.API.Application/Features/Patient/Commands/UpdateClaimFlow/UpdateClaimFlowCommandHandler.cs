using AutoMapper;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Models.Patient;
using Vertroue.HMS.API.Domain.Entities;
using Vertroue.HMS.API.Application.Shared;
using Azure.Storage.Blobs;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.UpdateClaimFlow
{
    public class UpdateClaimFlowCommandHandler : BlobHandler, IRequestHandler<UpdateClaimFlowCommand, ClaimFlowDto>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public UpdateClaimFlowCommandHandler(IMapper mapper,
            IPatientRepository patientRepository,
            ILoggedInUserService loggedInUserService,
            BlobServiceClient blobServiceClient) : base(blobServiceClient)
        {
            _loggedInUserService = loggedInUserService;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }


        public async Task<ClaimFlowDto> Handle(UpdateClaimFlowCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("User is not authorized to perform this operation.");

            var existingClaimFlow = await _patientRepository.GetClaimFlowByIdAsync(request.ClaimFlowId);
            var claimFlow = _mapper.Map<ClaimFlow>(request);
            claimFlow.CreatedBy = existingClaimFlow.CreatedBy;
            claimFlow.CreatedDate = existingClaimFlow.CreatedDate;

            var result = await _patientRepository.UpdateClaimFlowAsync(claimFlow);
            await _patientRepository.UpdateClaimFlowDocs(request.ClaimFlowDocIds, claimFlow.ClaimFlowId);

            foreach (var id in request.RemovedClaimFlowDocIds)
            {
                var docUri = await _patientRepository.DeleteClaimFlowDoc(id);
                if (!string.IsNullOrEmpty(docUri))
                {
                    await RemoveAsync(docUri, Constant.PatientDocsContainer);
                }
            }

            var claimflow = _mapper.Map<ClaimFlowDto>(result);
            var claimflowDocs = await _patientRepository.GetClaimFlowDocsByClaimFlowIdAsync(claimflow.ClaimFlowId);
            claimflow.ClaimFlowDocs = _mapper.Map<List<ClaimFlowDocDto>>(claimflowDocs);

            return claimflow;
        }
    }
}
