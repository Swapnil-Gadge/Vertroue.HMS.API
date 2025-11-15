using Azure.Storage.Blobs;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlowDoc
{
    public class CreateClaimFlowDocCommandHandler : BlobHandler, IRequestHandler<CreateClaimFlowDocCommand, CreateClaimFlowDocResponse>
    {
        private readonly IPatientRepository _patientRepository;

        public CreateClaimFlowDocCommandHandler(BlobServiceClient blobServiceClient,
            IPatientRepository patientRepository) : base(blobServiceClient)
        {
            _patientRepository = patientRepository;
        }

        public async Task<CreateClaimFlowDocResponse> Handle(CreateClaimFlowDocCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var file = request.Files.FirstOrDefault();
                if (file == null || file.Length <= 0) throw new Exception("File is missing...");

                foreach (var fileToUpload in request.Files)
                {
                    var uploadedfileUri = await UploadPatientDocAsync(fileToUpload, cancellationToken);
                    request.FileName = fileToUpload.FileName;
                    request.FileUrl = uploadedfileUri.ToString();
                }

                var docId = await _patientRepository.CreateClaimFlowDoc(request);
                return new CreateClaimFlowDocResponse
                {
                    ClaimFlowDocId = docId,
                    Id = request.Id,
                    FileName = request.FileName,
                    FileUrl = request.FileUrl
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
