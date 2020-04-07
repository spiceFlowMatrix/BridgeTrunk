using System.Threading.Tasks;

namespace Bridge.Application.Interfaces
{
    public interface ICommonServices
    {
        Task<string> Geturl(string str, string Certificate);
    }
}