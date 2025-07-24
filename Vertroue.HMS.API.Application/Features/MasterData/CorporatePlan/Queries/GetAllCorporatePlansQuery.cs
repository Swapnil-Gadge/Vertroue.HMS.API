using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Model;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Queries
{
    public record GetAllCorporatePlansQuery() : IRequest<List<CorporatePlanDto>>;
}