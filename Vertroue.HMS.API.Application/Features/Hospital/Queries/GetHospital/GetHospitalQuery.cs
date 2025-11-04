using MediatR;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospital
{
    public class GetHospitalQuery : IRequest<HospitalDto>
    {
        public int HospitalId { get; set; }
    }
}
