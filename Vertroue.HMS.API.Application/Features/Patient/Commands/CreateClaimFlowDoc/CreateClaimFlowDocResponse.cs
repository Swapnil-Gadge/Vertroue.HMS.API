namespace Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlowDoc
{
    public class CreateClaimFlowDocResponse
    {
        public int ClaimFlowDocId { get; set; }

        public int Id { get; set; }

        public string FileUrl { get; set; }

        public string FileName { get; set; }
    }
}
