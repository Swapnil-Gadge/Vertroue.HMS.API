using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Queries
{
    public record GetAllServiceRenewalsQuery : IRequest<List<CorporateServiceRenewalDto>>;
   
}