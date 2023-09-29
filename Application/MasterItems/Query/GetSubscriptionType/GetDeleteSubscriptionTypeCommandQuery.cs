using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.DeleteSubscriptionType;

namespace Wbc.Application.MasterItems.Query.GetSubscriptionType
{
  public class GetDeleteSubscriptionTypeCommandQuery : IRequest<DeleteSubscriptionTypeCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteSubscriptionTypeCommandQueryHandler : IRequestHandler<GetDeleteSubscriptionTypeCommandQuery, DeleteSubscriptionTypeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteSubscriptionTypeCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteSubscriptionTypeCommand> Handle(GetDeleteSubscriptionTypeCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SubscriptionTypes.FindAsync(request.Id);

            return _mapper.Map<DeleteSubscriptionTypeCommand>(entity);
        }
    }

    }
