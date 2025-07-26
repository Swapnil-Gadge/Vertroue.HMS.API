using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Enhancement
{
    public class UpdateCaseEnhancementCommandHandler : IRequestHandler<UpdateCaseEnhancementCommand, string>
    {
        private readonly IQMSDataRepository _repository;

        public UpdateCaseEnhancementCommandHandler(IQMSDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateCaseEnhancementCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateCaseEnhancementAsync(request);
        }
    }
}
