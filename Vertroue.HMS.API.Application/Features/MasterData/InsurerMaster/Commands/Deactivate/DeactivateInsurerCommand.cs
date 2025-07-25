
using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Deactivate
{
    public class DeactivateInsurerCommand : IRequest<string>
    {
        public int InsurerId { get; set; }
        public int UserId { get; set; }
    }
}
