using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateDoctorCommand
{
    public class CreateDoctorCommand : IRequest<bool>
    {
        public string? DoctorName { get; set; }

        public int? HospitalId { get; set; }

        public string? ContactNumber { get; set; }

        public string? Qualification { get; set; }

        public string? RegistrationNumber { get; set; }

        public bool? IsVisitingDoctor { get; set; }
    }
}
