using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Command.UpdateSubscriptionPlan
{
   public class UpdateSubscriptionPlanCommand : IRequest, IMapFrom<SubscriptionPlan>
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int ValidityPeriod { get; set; }
        public string Description { get; set; }
        public string Amout { get; set; }
        public int NoOfUse { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateSubscriptionPlanCommandHandler : IRequestHandler<UpdateSubscriptionPlanCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateSubscriptionPlanCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSubscriptionPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SubscriptionPlans.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SubscriptionPlan), request.Id);
            }

            entity.PlanName = request.PlanName;
            entity.SubscriptionTypeId = request.SubscriptionTypeId;
            entity.ValidityPeriod = request.ValidityPeriod;
            entity.Description = request.Description;
            entity.CountryId = request.CountryId;
            entity.Amout = request.Amout;
            entity.NoOfUse = request.NoOfUse;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
