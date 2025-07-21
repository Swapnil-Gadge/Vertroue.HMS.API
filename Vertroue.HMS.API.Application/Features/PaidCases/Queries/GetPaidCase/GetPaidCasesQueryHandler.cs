using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.PaidCases.Models;

namespace Vertroue.HMS.API.Application.Features.PaidCases.Queries.GetPaidCase
{
    public class GetPaidCasesQueryHandler : IRequestHandler<GetPaidCasesQuery, List<PaidCaseDto>>
    {
        private readonly IPaidCasesRepository _repository;

        public GetPaidCasesQueryHandler(IPaidCasesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PaidCaseDto>> Handle(GetPaidCasesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPaidCasesAsync(request.CorporateId, request.UserId, request.UserType, request.UserRole);
        }
    }
}
