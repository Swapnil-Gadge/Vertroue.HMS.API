using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IUserMasterRepository : IAsyncRepository<UserMaster>
    {
        Task<UserMaster> GetUserDetails(string userName);
    }
}
