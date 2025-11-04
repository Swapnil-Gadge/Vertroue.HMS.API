
using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Update
{
    public class UpdateInsurerCommand : IRequest<bool>
    {
        public int InsuranceCompanyId { get; set; }

        public string Name { get; set; } = null!;

        public string? ContactNumber { get; set; }

        public string? FaxNumber { get; set; }

        public string WebSite { get; set; } = null!;

        public string? Code { get; set; }
    }
}
