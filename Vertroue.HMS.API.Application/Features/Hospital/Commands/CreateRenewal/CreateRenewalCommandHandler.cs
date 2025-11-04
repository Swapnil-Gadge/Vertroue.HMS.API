using Azure.Storage.Blobs;
using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateRenewal
{
    public class CreateRenewalCommandHandler : BlobHandler, IRequestHandler<CreateRenewalCommand, bool>
    {
        private readonly IHospitalRepository _repository;
        private readonly ILoggedInUserService _loggedInUserService;

        public CreateRenewalCommandHandler(BlobServiceClient blobServiceClient, 
            IHospitalRepository repository, 
            ILoggedInUserService loggedInUserService) : base(blobServiceClient)
        {
            _repository = repository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<bool> Handle(CreateRenewalCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to perform this action.");

            try
            {
                var file = request.Files.FirstOrDefault();
                if (file == null || file.Length <= 0) throw new Exception("File is missing...");

                foreach (var fileToUpload in request.Files)
                {
                    var uploadedfileUri = await UploadAsync(fileToUpload, cancellationToken);
                    request.Documents.Add(fileToUpload.FileName, uploadedfileUri.ToString());
                }

                return await _repository.CreateNewRenewal(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
