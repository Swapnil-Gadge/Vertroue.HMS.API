using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.States.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.States.Queries
{
    public class GetAllStatesQuery : IRequest<List<StateDto>> { }
}
