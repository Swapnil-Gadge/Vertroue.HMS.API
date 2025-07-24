using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Commands.Deactivate
{
    public class DeactivateAdmissionTypeHandler : IRequestHandler<DeactivateAdmissionTypeCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateAdmissionTypeHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateAdmissionTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageAdmissionTypeAsync(request, 'D');
        }
    }
}