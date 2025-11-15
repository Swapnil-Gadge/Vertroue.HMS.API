using MediatR;
using Vertroue.HMS.API.Application.Models.Patient;

namespace Vertroue.HMS.API.Application.Features.Patient.Queries.GetPatient
{
    public class GetPatientQuery : IRequest<PatientDto>
    {
        public int PatientId { get; set; }

        public int HospitalId { get; set; }
    }
}
