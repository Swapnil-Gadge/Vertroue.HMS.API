
using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Deactivate
{
    public class DeactivateInsurerCommand : IRequest<bool>
    {
        public int InsuranceCompanyId { get; set; }
    }
}
