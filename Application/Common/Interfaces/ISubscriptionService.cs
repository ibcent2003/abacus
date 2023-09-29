using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Common.Interfaces
{
    public interface ISubscriptionService
    {
        Task<Subscriber> SubscribeAsync(Subscriber subscriber, CancellationToken cancellationToken);
    }
}
