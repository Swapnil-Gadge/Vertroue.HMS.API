using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Queries
{
    public record FetchCorporateTypeMasterQuery() : IRequest<List<CorporateTypeMasterDto>>;

}
