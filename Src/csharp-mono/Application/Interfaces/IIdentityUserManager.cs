using System.Threading.Tasks;
using Bridge.Application.Models;

namespace Application.Interfaces
{
    public interface IIdentityUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}