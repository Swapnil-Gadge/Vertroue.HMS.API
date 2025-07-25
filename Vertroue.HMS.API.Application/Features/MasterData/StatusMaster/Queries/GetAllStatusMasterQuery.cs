using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Queries
{
    public class GetAllStatusMasterQuery : IRequest<List<StatusMasterDto>>
    {
        public int UserId { get; set; }
    }
}
