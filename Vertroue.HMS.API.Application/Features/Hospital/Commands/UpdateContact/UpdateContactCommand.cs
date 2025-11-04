using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest<bool>
    {
        public int ContactId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ContactNo { get; set; }
        public int? EmpanelledInsCompId { get; set; }
        public int? EmpanelledTpaId { get; set; }
        public int HospitalId { get; set; }
    }
}
