using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.DeactivateCorporateTPACommand
{
    public record DeactivateCorporateTPACommand(
    int CorporateTPAId,
    int CorporateId,
    int UserId,
    string UserType,
    string UserRole
) : IRequest<string>;
}
