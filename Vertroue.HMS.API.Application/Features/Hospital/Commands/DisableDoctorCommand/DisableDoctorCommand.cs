using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableDoctorCommand
{
    public class DisableDoctorCommand : IRequest<bool>
    {
        public int DoctorId { get; set; }
    }
}
