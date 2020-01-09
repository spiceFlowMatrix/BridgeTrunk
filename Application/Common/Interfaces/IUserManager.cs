using System.Threading.Tasks;
using Bridge.Application.Common.Models;

namespace Bridge.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string firstName, string lastName, string userName, string email, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}