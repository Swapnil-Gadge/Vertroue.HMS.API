using Azure.Storage.Blobs;
using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateRenewal
{
    public class UpdateRenewalCommandHandler : BlobHandler, IRequestHandler<UpdateRenewalCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public UpdateRenewalCommandHandler(BlobServiceClient blobServiceClient,
            IHospitalRepository repository,
            ILoggedInUserService loggedInUserService) : base(blobServiceClient)
        {
            _hospitalRepository = repository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<bool> Handle(UpdateRenewalCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to perform this action.");

            try
            {
                var renewaldocs = await _hospitalRepository.GetRenewalDocs(request.RenewalId);
                var docsToRemove = renewaldocs.Where(x => request.DocumentsToRemove.Contains(x.RenewalDocId)).ToList();
                request.DocumentsToRemove = docsToRemove.Select(x => x.RenewalDocId).ToList();

                foreach (var fileToUpload in request.Files)
                {
                    var uploadedfileUri = await UploadAsync(fileToUpload, cancellationToken);
                    request.Documents.Add(fileToUpload.FileName, uploadedfileUri.ToString());
                }

                foreach (var doc in docsToRemove)
                {
                    await RemoveAsync(doc.DocUri);
                }

                return await _hospitalRepository.UpdateRenewal(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
