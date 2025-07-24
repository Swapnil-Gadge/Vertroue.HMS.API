using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Commands
{
    public class AddIdentificationTypeCommand : IRequest<string>
    {
        public string IdentificationTypeName { get; set; }
        public string IdentificationTypeDescription { get; set; }
        public int UserId { get; set; }
    }
}