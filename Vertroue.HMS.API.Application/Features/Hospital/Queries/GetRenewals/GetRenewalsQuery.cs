using MediatR;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetRenewals
{
    public class GetRenewalsQuery : IRequest<List<RenewalDto>>
    {
        public int HospitalId { get; set; }

        public int? RenewalId { get; set; }
    }
}
