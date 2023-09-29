using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;
using Wbc.Application.MasterItems.Command.UpdateSubscriptionPlan;

namespace Application.MasterItems.Command.UpdateSubscriptionPlan
{
    class UpdateSubscriptionPlanCommandValidator : AbstractValidator<UpdateSubscriptionPlanCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSubscriptionPlanCommandValidator(IApplicationDbContext context, CommonLocalizationService commonLocalizationService)
        {
            _context = context;

            RuleFor(x => x.CountryId).NotEmpty().WithName(commonLocalizationService.Get("CountryIdlbl"));
            RuleFor(x => x.SubscriptionTypeId).NotEmpty().WithName(commonLocalizationService.Get("SubscriptionTypeIdlbl"));
            RuleFor(x => x.ValidityPeriod).NotEmpty().WithName(commonLocalizationService.Get("ValidityPeriodlbl"));
            RuleFor(x => x.Description).NotEmpty().WithName(commonLocalizationService.Get("Descriptionlbl"));
            RuleFor(x => x.PlanName).NotEmpty().WithName(commonLocalizationService.Get("PlanNamelbl"))
           .MustAsync(BeUniquePlanName).WithMessage(commonLocalizationService.Get("ErrorBeUniquePlanNameRes"));
            RuleFor(x => x.Amout).NotEmpty().WithName(commonLocalizationService.Get("Amountlbl"));
            RuleFor(x => x.NoOfUse).NotEmpty().WithName(commonLocalizationService.Get("NoOfUselbl"));

        }
        public async Task<bool> BeUniquePlanName(string planName, CancellationToken cancellationToken)
        {
            return await _context.SubscriptionPlans
                .AllAsync(l => l.PlanName != planName, cancellationToken: cancellationToken);
        }
    }
}
