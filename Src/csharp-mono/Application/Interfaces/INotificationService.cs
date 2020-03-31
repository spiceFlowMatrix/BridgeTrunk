using Bridge.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Bridge.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
