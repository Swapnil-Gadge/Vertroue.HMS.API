using MediatR;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetDoctorsQuery
{
    public class GetDoctorsQuery : IRequest<List<DoctorDto>>
    {
        public int HospitalId { get; set; }

        public int? DoctorId { get; set; }
    }
}
