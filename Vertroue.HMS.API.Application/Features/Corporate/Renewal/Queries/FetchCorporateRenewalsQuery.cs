using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Queries
{
    public record FetchCorporateRenewalsQuery(
        int CorporateId,
        int UserId,
        string UserType,
        string UserRole
    ) : IRequest<FetchCorporateRenewalsResponse>;
}
