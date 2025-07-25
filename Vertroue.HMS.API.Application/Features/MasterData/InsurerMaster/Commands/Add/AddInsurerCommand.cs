
using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Add
{
    public class AddInsurerCommand : IRequest<string>
    {
        public string InsurerName { get; set; }
        public string InsurerCode { get; set; }
        public int UserId { get; set; }
    }
}
