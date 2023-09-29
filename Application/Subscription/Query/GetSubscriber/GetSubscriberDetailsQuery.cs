using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Query.GetProcessSubmittedDocument;

namespace Wbc.Application.Subscription.Query.GetSubscriber
{
    public class GetSubscriberDetailsQuery : IRequest<SubscriptionDetailsVm>
    {
        public int SubscriberId { get; set; }

    }

    public class GetSubscriberDetailsQueryHandler : IRequestHandler<GetSubscriberDetailsQuery, SubscriptionDetailsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSubscriberDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubscriptionDetailsVm> Handle(GetSubscriberDetailsQuery request, CancellationToken cancellationToken)
        {
            var subscriber = await _context.Subscribers.FirstAsync(x => x.DocumentId == request.SubscriberId, cancellationToken: cancellationToken);

            if (subscriber == null) throw new NotFoundException(nameof(subscriber));

            var userSubscription = await _context.UserSubscriptions.Where(x => x.SubscriberId == subscriber.Id).FirstOrDefaultAsync();

            var submittedDocuments = await _context.ProcessSubmittedDocuments.Where(x => x.DocumentOwnerId == subscriber.ParentId).ProjectTo<ProcessSubmittedDocumentDto>(_mapper.ConfigurationProvider).ToListAsync();

            var subscriberDto = _mapper.Map<SubscriptionDto>(subscriber);

            subscriberDto.FirstName = userSubscription.FirstName;
            subscriberDto.MiddleName = userSubscription.MiddleName;
            subscriberDto.LastName = userSubscription.LastName;
            subscriberDto.AdminPhoneNumber = userSubscription.PhoneNumber;
            subscriberDto.AdminEmailAddress = userSubscription.EmailAddress;

            return new SubscriptionDetailsVm { SubscriptionDto = subscriberDto, SubmittedDocuments = submittedDocuments };


        }
    }
}
