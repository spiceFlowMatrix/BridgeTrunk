using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserHelper
    {
        Task<string> getUserId(string authid);
    }
}