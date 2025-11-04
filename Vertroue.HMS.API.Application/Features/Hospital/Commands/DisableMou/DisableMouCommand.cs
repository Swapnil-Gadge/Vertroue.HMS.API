using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableMou
{
    public class DisableMouCommand : IRequest<bool>
    {
        public int MouId { get; set; }
    }
}
