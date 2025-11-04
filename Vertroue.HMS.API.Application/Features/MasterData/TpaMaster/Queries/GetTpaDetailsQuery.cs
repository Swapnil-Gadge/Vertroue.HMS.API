using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Queries
{
    public class GetTpaDetailsQuery : IRequest<TpaMasterDto>
    {
        public int TpaId { get; set; }
    }
}
