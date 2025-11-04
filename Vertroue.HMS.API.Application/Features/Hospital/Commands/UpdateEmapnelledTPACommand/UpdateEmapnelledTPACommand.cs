using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateEmapnelledTPACommand
{
    public class UpdateEmapnelledTPACommand : IRequest<bool>
    {
        public int EmpanelledTpaId { get; set; }

        public int? TpaId { get; set; }

        public string Portal { get; set; } = null!;

        public string? UserName { get; set; }

        public string? PassWord { get; set; }

        public DateTime? EmpanelledDate { get; set; }
    }
}
