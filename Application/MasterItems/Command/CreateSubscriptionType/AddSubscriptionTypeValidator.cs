using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Command.CreateSubscriptionType
{
   public class AddSubscriptionTypeValidator : AbstractValidator<AddSubscriptionTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddSubscriptionTypeValidator(CommonLocalizationService localizationService, IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Name).NotEmpty().WithName(localizationService.Get("SubscriptionTypeNamelbl"))
                .MustAsync(BeUniqueSubscriptionTypeName).WithMessage(localizationService.Get("ErrorBeUniqueSubscriptionTypeName"));              
                       

            RuleFor(x => x.Description).NotEmpty().WithName(localizationService.Get("Descriptionlbl"));
            RuleFor(x => x.IsActive).NotEmpty();
        }

        public async Task<bool> BeUniqueSubscriptionTypeName(string name, CancellationToken cancellationToken)
        {
            return await _context.SubscriptionTypes
                .AllAsync(l => l.Name != name, cancellationToken: cancellationToken);
        }

      



    }
}
