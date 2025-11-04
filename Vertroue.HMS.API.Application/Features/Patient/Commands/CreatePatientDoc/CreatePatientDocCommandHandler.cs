using Azure.Storage.Blobs;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.CreatePatientDoc
{
    public class CreatePatientDocCommandHandler : BlobHandler, IRequestHandler<CreatePatientDocCommand, CreatePatientDocResponse>
    {
        private readonly IPatientRepository _patientRepository;

        public CreatePatientDocCommandHandler(BlobServiceClient blobServiceClient, 
            IPatientRepository patientRepository): base(blobServiceClient)
        {
            _patientRepository = patientRepository;
        }

        public async Task<CreatePatientDocResponse> Handle(CreatePatientDocCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var file = request.Files.FirstOrDefault();
                if (file == null || file.Length <= 0) throw new Exception("File is missing...");

                foreach (var fileToUpload in request.Files)
                {
                    var uploadedfileUri = await UploadMouAsync(fileToUpload, cancellationToken);
                    request.FileName = fileToUpload.FileName;
                    request.FileUrl = uploadedfileUri.ToString();
                }

                var docId = await _patientRepository.CreatePatientDoc(request);
                return new CreatePatientDocResponse { 
                    PatientDocId = docId,
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
