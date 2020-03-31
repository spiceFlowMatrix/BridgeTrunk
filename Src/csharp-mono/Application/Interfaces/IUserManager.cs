using System.Threading.Tasks;
using Bridge.Application.Models;

namespace Bridge.Application.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string firstName, string lastName, string userName, string email, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<Result> GetClients();
        Task<Result> GetClient(string clientId);
        Task<Result> CreateClientAsync(string clientId);
        Task<Result> EditClientAsync(string clientId);
        Task<Result> BlockClientAsync(string clientId);
        void Dispose();
    }
}