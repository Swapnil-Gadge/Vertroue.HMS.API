using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Commands
{
    public class DeactivateIdentificationTypeCommand : IRequest<string>
    {
        public int IdentificationTypeId { get; set; }
        public int UserId { get; set; }
    }
}