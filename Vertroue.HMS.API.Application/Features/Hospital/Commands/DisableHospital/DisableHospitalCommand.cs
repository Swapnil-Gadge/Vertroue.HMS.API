using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableHospital
{
    public class DisableHospitalCommand : IRequest<bool>
    {
        public int HospitalId { get; set; }
    }
}
