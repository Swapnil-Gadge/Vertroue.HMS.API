
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateRenewal
{
    public class CreateRenewalCommand : IRequest<bool>
    {
        public IFormFileCollection Files { get; set; }

        public int HospitalId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime? RenewalDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public Dictionary<string, string> Documents { get; set; } = new Dictionary<string, string>();
    }
}
