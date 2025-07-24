using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Commands.Deactivate
{
    public class DeactivateGenderCommand : IRequest<string>
    {
        public int GenderId { get; set; }
        public int UserId { get; set; }
    }
}