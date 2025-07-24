using MediatR;

namespace Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Commands.Update
{
    public class UpdateGenderCommand : IRequest<string>
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public int UserId { get; set; }
    }
}