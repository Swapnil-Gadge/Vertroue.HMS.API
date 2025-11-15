using AutoMapper;
using Azure.Storage.Blobs;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.DeleteClaimFlow
{
    public class DeleteClaimFlowCommandHandler : BlobHandler, IRequestHandler<DeleteClaimFlowCommand, bool>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public DeleteClaimFlowCommandHandler(IMapper mapper,
            IPatientRepository patientRepository,
            ILoggedInUserService loggedInUserService,
            BlobServiceClient blobServiceClient) : base(blobServiceClient)
        {
            _loggedInUserService = loggedInUserService;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteClaimFlowCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                    throw new UnauthorizedAccessException("User is not authorized to perform this operation.");

                var claimFlowDocs = await _patientRepository.GetClaimFlowDocsByClaimFlowIdAsync(request.ClaimFlowId);
                foreach (var doc in claimFlowDocs)
                {
                    if (doc != null)
                    {
                        var documentUi = await _patientRepository.DeleteClaimFlowDoc(doc.ClaimFlowDocId);
                        await RemoveAsync(documentUi, Constant.PatientDocsContainer);                        
                    }
                }

                await _patientRepository.DeleteClaimFlow(request.ClaimFlowId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
            
        }
    }
}
