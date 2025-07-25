
using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Update
{
    public class UpdateInsurerCommand : IRequest<string>
    {
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
        public string InsurerCode { get; set; }
        public int UserId { get; set; }
    }
}
