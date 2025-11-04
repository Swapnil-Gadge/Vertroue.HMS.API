using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetMous
{
    public class GetMousQuery : IRequest<GetMousQueryResponse>
    {
        public int? EmpanelledInsCompId { get; set; }
        public int? EmpanelledTpaId { get; set; }
        public int? MouId { get; set; }
        public int HospitalId { get; set; }
    }
}
