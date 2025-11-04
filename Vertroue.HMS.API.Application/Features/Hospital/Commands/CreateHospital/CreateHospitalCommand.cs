using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateHospital
{
    public class CreateHospitalCommand : IRequest<bool>
    {
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string WebSite { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }

        public int CityId { get; set; }

        public int StateId { get; set; }
    }
}
