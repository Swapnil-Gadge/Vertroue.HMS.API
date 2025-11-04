using MediatR;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospitals
{
    public class GetHospitalsQuery : IRequest<List<HospitalDto>>
    {
    }
}
