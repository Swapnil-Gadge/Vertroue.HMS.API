using MediatR;
using Vertroue.HMS.API.Application.Models.Patient;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.UpdatePatient
{
    public class UpdatePatientCommand : IRequest<PatientDto>
    {
        public PatientDto PatientDto { get; set; }
    }
}
