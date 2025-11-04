using MediatR;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetEmapnelledTpaQuery
{
    public class GetEmapnelledTpaQuery : IRequest<List<EmpanelledTpaDto>>
    {
        public int HospitalId { get; set; }

        public int? EmpanelledTpaId { get; set; }
    }
}
