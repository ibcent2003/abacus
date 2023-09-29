using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.DeleteSubscriptionPlan;

namespace Wbc.Application.MasterItems.Query.GetSubscriptionPlan
{
    public class GetDeleteSubscriptionPlanCommandQuery : IRequest<DeleteSubscriptionPlanCommand>
    {
        public int Id { get; set; }
    }
    public class GetDeleteSubscriptionPlanCommandQueryHandler : IRequestHandler<GetDeleteSubscriptionPlanCommandQuery, DeleteSubscriptionPlanCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteSubscriptionPlanCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

     
    public async Task<DeleteSubscriptionPlanCommand> Handle(GetDeleteSubscriptionPlanCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SubscriptionPlans.Include(x => x.SubscriptionType).Include(x=>x.Country).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var SubscriptionPlanDto = _mapper.Map<SubscriptionPlanDto>(entity);

            return _mapper.Map<DeleteSubscriptionPlanCommand>(SubscriptionPlanDto);
        }      
    }

 }
