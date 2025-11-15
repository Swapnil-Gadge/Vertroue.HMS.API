using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospitalData
{
    public class GetHospitalDataQuery : IRequest<GetHospitalDataResponse>
    {
        public int HospitalId { get; set; }
    }
}
