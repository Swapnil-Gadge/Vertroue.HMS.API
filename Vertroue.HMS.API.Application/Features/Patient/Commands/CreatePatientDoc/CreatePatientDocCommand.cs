using MediatR;
using Microsoft.AspNetCore.Http;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.CreatePatientDoc
{
    public class CreatePatientDocCommand : IRequest<CreatePatientDocResponse>
    {
        public IFormFileCollection Files { get; set; }

        public int PatientId { get; set; }

        public string DocumentType { get; set; } = null!;

        public string FileName { get; set; } = null!;

        public string FileUrl { get; set; } = null!;

        public int PatientDocId { get; set;  }
    }
}
