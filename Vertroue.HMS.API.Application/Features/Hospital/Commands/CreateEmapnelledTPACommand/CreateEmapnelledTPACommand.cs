using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateEmapnelledTPACommand
{
    public class CreateEmapnelledTPACommand : IRequest<bool>
    {
        public int? TpaId { get; set; }

        public string Portal { get; set; } = null!;

        public string? UserName { get; set; }

        public string? PassWord { get; set; }

        public int? HospitalId { get; set; }

        public DateTime? EmpanelledDate { get; set; }
    }
}
