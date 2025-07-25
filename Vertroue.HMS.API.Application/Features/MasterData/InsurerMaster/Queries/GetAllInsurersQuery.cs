
using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Model;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Queries
{
    public class GetAllInsurersQuery : IRequest<List<InsurerDto>> { }
}
