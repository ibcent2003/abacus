using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.MasterItems.CreateSubscriptionPlan
{
   public class CreateSubscriptionPlanCommand : IRequest<int>
    {       
        public string PlanName { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int ValidityPeriod { get; set; }
        public string Description { get; set; }
        public string Amout { get; set; }
        public int NoOfUse { get; set; }
        public int CountryId { get; set; }       
        public bool IsActive { get; set; }
    }
    public class CreateSubscriptionPlanCommandHandler : IRequestHandler<CreateSubscriptionPlanCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateSubscriptionPlanCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSubscriptionPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.SubscriptionPlan
            {
                PlanName = request.PlanName,
                SubscriptionTypeId = request.SubscriptionTypeId,
                ValidityPeriod = request.ValidityPeriod,
                Description = request.Description,
                Amout = request.Amout,
                NoOfUse = request.NoOfUse,
                IsActive = true,
                CountryId = request.CountryId
            };

            _context.SubscriptionPlans.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

}
