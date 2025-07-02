namespace Vertroue.HMS.API.Application.Contracts
{
    public interface ILoggedInUserService
    {
        public string? UserId { get; }

        public int CorporateId { get; }

        public int UserLoginId { get; }

        public string UserType { get; }

        public string UserRole { get; }
    }
}
