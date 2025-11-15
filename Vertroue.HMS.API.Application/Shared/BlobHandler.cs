using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace Vertroue.HMS.API.Application.Shared
{
    public class BlobHandler
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobHandler(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public Task<Uri> UploadAsync(IFormFile file, CancellationToken cancellationToken) =>
            UploadToContainerAsync(file, Constant.RenewalDocsContainer, cancellationToken);

        public Task<Uri> UploadMouAsync(IFormFile file, CancellationToken cancellationToken) =>
            UploadToContainerAsync(file, Constant.MouDocsContainer, cancellationToken);

        public Task<Uri> UploadPatientDocAsync(IFormFile file, CancellationToken cancellationToken) =>
            UploadToContainerAsync(file, Constant.PatientDocsContainer, cancellationToken);

        public async Task<Uri> UploadToContainerAsync(IFormFile file, string containerName, CancellationToken cancellationToken)
        {
            // Get or create the container
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.None, cancellationToken: cancellationToken);

            // Create unique blob name
            string blobName = Guid.NewGuid() + file.FileName.Replace(" ", "_");
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // Set upload options
            var uploadOptions = new BlobUploadOptions
            {
                TransferOptions = new StorageTransferOptions
                {
                    MaximumConcurrency = 4,
                    MaximumTransferSize = 4 * 1024 * 1024,
                    InitialTransferSize = 4 * 1024 * 1024
                }
            };

            // Upload
            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, uploadOptions, cancellationToken);
            }

            return blobClient.Uri;
        }

        public async Task<bool> RemoveAsync(string fileUri, string containerName)
        {
            var uri = new Uri(fileUri);
            var fileName = uri.Segments.LastOrDefault() ?? string.Empty;
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            var blob = container.GetBlobClient(fileName);
            return await blob.DeleteIfExistsAsync();
        }
    }
}
