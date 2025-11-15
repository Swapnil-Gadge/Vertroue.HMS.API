using MediatR;
using Vertroue.HMS.API.Application.Models.Patient;

namespace Vertroue.HMS.API.Application.Features.Patient.Queries.GetPatients
{
    public class GetPatientsQuery : IRequest<List<PatientDto>>
    {
        public int HospitalId { get; set; }
    }
}
