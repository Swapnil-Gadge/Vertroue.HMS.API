using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Queries
{
    public record FetchCorporateMOUQuery(
         int CorporateId,
         int UserId,
         string UserType,
         string UserRole
     ) : IRequest<List<CorporateMouDto>>;
}
