using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Common.Interfaces;
using Bridge.Application.Notifications.Models;
using MediatR;

namespace Bridge.Application.Clients.Commands.CreateCustomer
{
    public class ClientCreated : INotification
    {
        public string ClientId { get; set; }

        public class CustomerCreatedHandler : INotificationHandler<ClientCreated>
        {
            private INotificationService _notification;

            public CustomerCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(ClientCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}