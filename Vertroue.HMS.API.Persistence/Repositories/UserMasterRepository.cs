using Microsoft.EntityFrameworkCore;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class UserMasterRepository : BaseRepository<UserMaster>, IUserMasterRepository
    {
        public UserMasterRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserMaster> GetUserDetails(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("Username is empty");

            return await _dbContext.User_Master
                .Include(u => u.Corporate)
                .Include(u => u.UserRole)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower());
        }
    }
}
