using Azure.Storage.Blobs;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateMou
{
    public class CreateMouCommandHandler : BlobHandler, IRequestHandler<CreateMouCommand, bool>
    {
        private readonly IHospitalRepository _repository;

        public CreateMouCommandHandler(BlobServiceClient blobServiceClient,
            IHospitalRepository repository) : base(blobServiceClient)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateMouCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var file = request.Files.FirstOrDefault();
                if (file == null || file.Length <= 0) throw new Exception("File is missing...");

                foreach (var fileToUpload in request.Files)
                {
                    var uploadedfileUri = await UploadMouAsync(fileToUpload, cancellationToken);
                    request.DocName = fileToUpload.FileName;
                    request.DocUri = uploadedfileUri.ToString();
                }

                return await _repository.AddUpdateMou(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }            
        }
    }
}
