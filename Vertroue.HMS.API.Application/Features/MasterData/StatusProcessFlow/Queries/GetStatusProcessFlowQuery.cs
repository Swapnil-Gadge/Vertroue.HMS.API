using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Queries
{
    public class GetStatusProcessFlowQuery : IRequest<List<StatusProcessFlowDto>>
    {
    }
}
