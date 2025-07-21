using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Commands
{
    public record SaveParentCorporateCommand(
    string CorporateName,
    string CorporateAddress,
    int StateId,
    int CityId,
    string Pincode,
    string ContactNo,
    int ZoneId,
    string Website,
    string Email,
    int UserId,
    string UserType,
    string UserRole
) : IRequest<SaveParentCorporateResponse>;
}
