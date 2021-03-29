using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WebApi.MediatTest
{
    public class PingNotification1 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            return Task.FromResult($"PingNotification1 {notification.SendingTime}");
        }
    }

    public class PingNotification2 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            return Task.FromResult($"PingNotification2 {notification.SendingTime}");
        }
    }
}
