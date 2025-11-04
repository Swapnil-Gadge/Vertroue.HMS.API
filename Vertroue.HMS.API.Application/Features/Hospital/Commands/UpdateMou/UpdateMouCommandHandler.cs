using Azure.Storage.Blobs;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateMou
{
    public class UpdateMouCommandHandler : BlobHandler, IRequestHandler<UpdateMouCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public UpdateMouCommandHandler(BlobServiceClient blobServiceClient, IHospitalRepository hospitalRepository): base(blobServiceClient)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(UpdateMouCommand request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var fileToUpload in request.Files)
                {
                    var uploadedfileUri = await UploadMouAsync(fileToUpload, cancellationToken);
                    request.DocUri = uploadedfileUri.ToString();
                }

                return await _hospitalRepository.AddUpdateMou(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }            
        }
    }
}
