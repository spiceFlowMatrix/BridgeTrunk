using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Bridge.Domain.Entities;

namespace Application.Helpers
{
    public class UserHelper: IUserHelper
    {
        private readonly IBridgeDbContext _dbContext;
        public UserHelper(IBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //getting userid by auth0 id
        public async Task<string> getUserId(string authid)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(b => b.AuthId == authid && b.IsDeleted == false);
            if (user != null)
            {
                return user.Id.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}