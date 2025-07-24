using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Commands.Add
{
    public class AddGenderCommand : IRequest<string>
    {
        public string GenderName { get; set; }
        public int UserId { get; set; }
    }
}