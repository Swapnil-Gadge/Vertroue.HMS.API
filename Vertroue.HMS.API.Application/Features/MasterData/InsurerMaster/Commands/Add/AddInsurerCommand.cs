
using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Add
{
    public class AddInsurerCommand : IRequest<bool>
    {
        public string Name { get; set; } = null!;

        public string? ContactNumber { get; set; }

        public string? FaxNumber { get; set; }

        public string WebSite { get; set; } = null!;

        public string? Code { get; set; }
    }
}
