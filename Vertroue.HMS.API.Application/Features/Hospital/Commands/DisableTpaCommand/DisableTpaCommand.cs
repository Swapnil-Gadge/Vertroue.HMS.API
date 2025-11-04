using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableTpaCommand
{
    public class DisableTpaCommand : IRequest<bool>
    {
        public int EmpanelledTpaId { get; set; }
    }
}
