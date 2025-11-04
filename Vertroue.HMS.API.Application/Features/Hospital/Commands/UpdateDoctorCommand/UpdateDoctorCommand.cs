using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateDoctorCommand
{
    public class UpdateDoctorCommand : IRequest<bool>
    {
        public int DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public string? ContactNumber { get; set; }

        public string? Qualification { get; set; }

        public string? RegistrationNumber { get; set; }

        public bool? IsVisitingDoctor { get; set; }
    }
}
