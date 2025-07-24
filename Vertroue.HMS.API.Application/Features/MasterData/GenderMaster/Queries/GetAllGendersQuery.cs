using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Model;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Queries
{
    public class GetAllGendersQuery : IRequest<List<GenderDto>>
    {
    }
}