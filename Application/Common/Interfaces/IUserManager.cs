using System.Threading.Tasks;
using Bridge.Application.Common.Models;
using Bridge.Domain.Entities;

namespace Bridge.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result result, User user)> CreateUserAsync(string userName, string email, string password);
        Task<Result> DeleteUserAsync(string userId);
        // Omits editing userId, email, email verified, 
        // password, phone number, phone verified, blocked
        Task<(Result result, User user)> EditUserAsync(string userId, User editedUser);
        Task<Result> ResetPassword(string newPassword);
        Task<Result> ResetEmail(string newEmail);
        Task<Result> ResetPhoneNumber(string newPhoneNumber);
        Task<Result> ToggleBlocked();
    }
}