using System;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public Task<int> SendSms(string recipientNumber, string title, string message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> SendEmail(string recipientMail, string subject, string message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
