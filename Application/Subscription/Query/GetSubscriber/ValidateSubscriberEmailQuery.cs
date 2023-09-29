using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Subscription.Query.GetSubscriber
{
    public class ValidateSubscriberEmailQuery : IRequest<bool>
    {
        public string EmailAddress { get; set; }

    }

    public class ValidateSubscriberEmailQueryHandler : IRequestHandler<ValidateSubscriberEmailQuery, bool>
    {
        private readonly IApplicationDbContext _dbContext;
        public ValidateSubscriberEmailQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(ValidateSubscriberEmailQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Subscribers.AnyAsync(x => x.EmailAddress.Equals(request.EmailAddress), cancellationToken);
        }
    }
}
