using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Subscription.Command.AddSubscriber;

namespace Wbc.Infrastructure.Services
{
    public class LongRunningTaskProcessor : ILongRunningTaskProccesor
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public LongRunningTaskProcessor(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task ProcessFile(int fileId, CancellationToken cancellationToken)
        {
            var pendingTransaction = await _context.LongRunningRequestTemps.FindAsync(fileId);

            if (pendingTransaction == null) return;

            var process = EnumHelper.GetEnumFromString<Process>(pendingTransaction.ProcessCode);

            try
            {
                switch (process)
                {
                    case Process.ChamberSubscriptionProcess:
                        await _mediator.Send(new AddSubscriberHostedServiceCommand { JsonString = pendingTransaction.JsonContent }, cancellationToken);
                        break;
                    case Process.TraderSubscriptionProcess:
                        await _mediator.Send(new AddSubscriberHostedServiceCommand { JsonString = pendingTransaction.JsonContent }, cancellationToken);
                        break;
                    case Process.AgentSubscriptionProcess:
                        await _mediator.Send(new AddSubscriberHostedServiceCommand { JsonString = pendingTransaction.JsonContent }, cancellationToken);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            finally
            {
                pendingTransaction.IsProcessed = true;

                await _context.SaveChangesAsync(cancellationToken);
            }

        }
    }
}
