using MediatR;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.DeletePatientDoc
{
    public class DeletePatientDocCommand : IRequest<bool>
    {
        public int PatientDocId { get; set; }
    }
}
