using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.UpdateSubscriptionType;


namespace Wbc.Application.MasterItems.Query.GetSubscriptionType
{
    public class GetUpdateSubscriptionTypeCommandQuery : IRequest<UpdateSubscriptionTypeCommand>
    {
        public int Id { get; set; }
    }
    public class GetUpdateSubscriptionTypeCommandQueryHandler : IRequestHandler<GetUpdateSubscriptionTypeCommandQuery, UpdateSubscriptionTypeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateSubscriptionTypeCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateSubscriptionTypeCommand> Handle(GetUpdateSubscriptionTypeCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SubscriptionTypes.FindAsync(request.Id);

            return _mapper.Map<UpdateSubscriptionTypeCommand>(entity);
        }
    }

    }
