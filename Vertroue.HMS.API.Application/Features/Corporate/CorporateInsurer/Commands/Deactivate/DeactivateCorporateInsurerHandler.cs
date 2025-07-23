using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Deactivate
{
    public class DeactivateCorporateInsurerHandler : IRequestHandler<DeactivateCorporateInsurerCommand, string>
    {
        private readonly ICorporateRepository _repository;

        public DeactivateCorporateInsurerHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateCorporateInsurerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeactivateCorporateInsurerAsync(
                request.CorporateInsurerId, request.CorporateId,
                request.UserId, request.UserType, request.UserRole);
        }
    }
}
