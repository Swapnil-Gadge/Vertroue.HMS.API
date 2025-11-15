using Azure.Storage.Blobs;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.DeleteClaimFlowDoc
{
    public class DeleteClaimFlowDocCommandHandler : BlobHandler, IRequestHandler<DeleteClaimFlowDocCommand, bool>
    {
        private readonly IPatientRepository _patientRepository;

        public DeleteClaimFlowDocCommandHandler(IPatientRepository patientRepository
            , BlobServiceClient blobServiceClient) : base(blobServiceClient)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> Handle(DeleteClaimFlowDocCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var uri = await _patientRepository.DeleteClaimFlowDoc(request.ClaimFlowDocId);
                if (!string.IsNullOrEmpty(uri))
                {
                    await RemoveAsync(uri, Constant.PatientDocsContainer);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
