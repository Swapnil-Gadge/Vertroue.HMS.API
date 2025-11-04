using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.DisableTpaCommand
{
    public class DisableTpaCommandHandler : IRequestHandler<DisableTpaCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;

        public DisableTpaCommandHandler(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> Handle(DisableTpaCommand request, CancellationToken cancellationToken)
        {
            return await _hospitalRepository.DisableEmpanelledTpa(request.EmpanelledTpaId);
        }
    }
}
