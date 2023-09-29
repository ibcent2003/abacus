using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.UpdateSubscriptionType;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Commands.UpdateSubscriptionType
{
    public class UpdateSubscriptionTypeCommandValidator : AbstractValidator<UpdateSubscriptionTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSubscriptionTypeCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
           
            _context = context;
            RuleFor(x => x.Name).NotEmpty().WithName(localizationService.Get("SubscriptionTypenNamelbl"));
               

            RuleFor(x => x.Description).NotEmpty().WithName(localizationService.Get("Descriptionlbl"));
            RuleFor(x => x.IsActive).NotEmpty();

        }
      
    }
}
