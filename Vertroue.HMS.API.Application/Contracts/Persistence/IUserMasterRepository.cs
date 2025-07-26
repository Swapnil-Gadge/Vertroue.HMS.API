using Vertroue.HMS.API.Application.Features.Users.Model;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IUserMasterRepository : IAsyncRepository<UserMaster>
    {
        Task<UserMaster> GetUserDetails(string userName);
        Task<LoginResponseDto> ValidateLoginAsync(string userId, string password, string userType);
        Task<bool> UpdatePasswordAsync(int userId, string oldPassword, string newPassword);
    }
}
