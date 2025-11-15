using MediatR;
using Microsoft.AspNetCore.Http;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlowDoc
{
    public class CreateClaimFlowDocCommand :IRequest<CreateClaimFlowDocResponse>
    {
        public IFormFileCollection Files { get; set; }

        public string FileName { get; set; } = null!;

        public string? FileUrl { get; set; } = null!;

        public int Id { get; set; }
    }
}
