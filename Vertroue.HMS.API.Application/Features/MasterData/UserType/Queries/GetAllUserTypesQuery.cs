using MediatR;
using System.Collections.Generic;
using Vertroue.HMS.API.Application.Features.MasterData.UserType.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserType.Queries
{
    public class GetAllUserTypesQuery : IRequest<List<UserTypeDto>>
    {
    }
}
