namespace Vertroue.HMS.API.Application.Contracts
{
    public interface ILoggedInUserService
    {
        public string? UserId { get; }

        public int HospitalId { get; }

        public string? UserName { get; }

        public bool IsUserUnauthorizedToPerformOperation(int hospitalId);

        public int CorporateId { get; }

        public int UserLoginId { get; }

        public string UserType { get; }

        public string UserRole { get; }
    }
}
