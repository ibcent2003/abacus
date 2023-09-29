using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Query.GetProcessRequiredDocument;

namespace Wbc.Application.Subscription.Query.GetSubscriber
{
    public class GetSubscriberCommandQuery : IRequest<SubscriptionVm>
    {
        public Process Process { get; set; }

    }

    public class GetSubscriptionCommandQueryHandler : IRequestHandler<GetSubscriberCommandQuery, SubscriptionVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSubscriptionCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubscriptionVm> Handle(GetSubscriberCommandQuery request, CancellationToken cancellationToken)
        {
            var processCode = request.Process.GetAttributeStringValue();

            var requiredDocument = await _context.ProcessRequiredDocuments.Where(x => x.ProcessCode.Equals(processCode)).ProjectTo<SupportingDocumentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new SubscriptionVm { SupportingDocumentDtos = requiredDocument };
        }
    }
}