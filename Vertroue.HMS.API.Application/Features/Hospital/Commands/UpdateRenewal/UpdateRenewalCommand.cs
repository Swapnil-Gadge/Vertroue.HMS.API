using MediatR;
using Microsoft.AspNetCore.Http;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateRenewal
{
    public class UpdateRenewalCommand : IRequest<bool>
    {
        public IFormFileCollection Files { get; set; }

        public int RenewalId { get; set; }

        public int HospitalId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime? RenewalDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public List<int> DocumentsToRemove { get; set; }

        public Dictionary<string, string> Documents { get; set; }
    }
}
