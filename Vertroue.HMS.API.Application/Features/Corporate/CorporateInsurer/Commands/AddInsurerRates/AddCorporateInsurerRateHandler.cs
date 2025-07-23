using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.AddInsurerRates
{
    public class AddCorporateInsurerRateHandler : IRequestHandler<AddCorporateInsurerRateCommand, string>
    {
        private readonly ICorporateRepository _repository;

        public AddCorporateInsurerRateHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddCorporateInsurerRateCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddCorporateInsurerRateAsync(request);
        }
    }
}
