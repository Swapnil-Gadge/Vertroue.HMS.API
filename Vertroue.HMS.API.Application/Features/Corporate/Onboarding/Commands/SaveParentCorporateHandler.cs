using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Commands
{
    public class SaveParentCorporateHandler : IRequestHandler<SaveParentCorporateCommand, SaveParentCorporateResponse>
    {
        private readonly ICorporateRepository _repo;

        public SaveParentCorporateHandler(ICorporateRepository repo)
        {
            _repo = repo;
        }

        public async Task<SaveParentCorporateResponse> Handle(SaveParentCorporateCommand request, CancellationToken cancellationToken)
        {
            return await _repo.SaveParentCorporateAsync(request);
        }
    }
}
