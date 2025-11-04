using MediatR;
using Microsoft.AspNetCore.Http;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateMou
{
    public class CreateMouCommand : IRequest<bool>
    {
        public IFormFileCollection Files { get; set; }
        public int HospitalId { get; set; }
        public int? EmpanelledInsCompId { get; set; }
        public int? EmpanelledTpaId { get; set; }
        public string DocName { get; set; } = null!;
        public string DocUri { get; set; } = null!;
        public DateTime? MouStartDate { get; set; }
        public DateTime? MouEndDate { get; set; }
    }
}
