using MediatR;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Commands
{
    public class UpdateCorporateFileSentCommandHandler : IRequestHandler<UpdateCorporateFileSentCommand, string>
    {
        private readonly IQMSDataRepository _qmsRepository;

        public UpdateCorporateFileSentCommandHandler(IQMSDataRepository qmsRepository)
        {
            _qmsRepository = qmsRepository;
        }

        public async Task<string> Handle(UpdateCorporateFileSentCommand request, CancellationToken cancellationToken)
        {
            return await _qmsRepository.UpdateCorporatePendingFileSentAsync(request);
        }
    }
}
