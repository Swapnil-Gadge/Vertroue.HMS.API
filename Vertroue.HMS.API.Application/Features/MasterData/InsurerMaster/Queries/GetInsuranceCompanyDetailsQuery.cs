using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Queries
{
    public class GetInsuranceCompanyDetailsQuery : IRequest<InsurerDto>
    {
        public int InsuranceCompanyId { get; set; }
    }
}
