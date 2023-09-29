using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Application.MasterItems.Command.UpdateHSCodePool
{
    public class UpdateHSCodePoolCommandValidator : AbstractValidator<UpdateHSCodePoolCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateHSCodePoolCommandValidator(IApplicationDbContext context, CommonLocalizationService commonLocalizationService)
        {
            _context = context;

            RuleFor(x => x.Description).NotEmpty().WithName(commonLocalizationService.Get("Descriptionlbl"));
            RuleFor(x => x.CountryId).NotEmpty().WithName(commonLocalizationService.Get("CountryIdlbl"));
            RuleFor(x => x.StandardUnitOfQuantity).NotEmpty().WithName(commonLocalizationService.Get("StandardUnitOfQuantitylbl"));
            RuleFor(x => x.Heading).NotEmpty().WithName(commonLocalizationService.Get("Headinglbl")).MustAsync(BeUniqueHeading).WithMessage(commonLocalizationService.Get("ErrorBeUniqueHeadingRes"));
            RuleFor(x => x.HSCode).NotEmpty().WithName(commonLocalizationService.Get("HSCodelbl")).MustAsync(BeUniqueHSCode).WithMessage(commonLocalizationService.Get("ErrorBeUniqueHSCodeRes")).Must(NotContainSpace).WithMessage(commonLocalizationService.Get("ErrorNoSpaceInHSCodeRes"));
        }

        public async Task<bool> BeUniqueHeading(UpdateHSCodePoolCommand request,string heading, CancellationToken cancellationToken)
        {
            return await _context.HSCodePools.Where(x => x.Id != request.Id).AllAsync(x => x.Heading != heading, cancellationToken);
        }

        public async Task<bool> BeUniqueHSCode(UpdateHSCodePoolCommand request,string hscode, CancellationToken cancellationToken)
        {
            return await _context.HSCodePools.Where(x => x.Id != request.Id).AllAsync(x => x.HSCode != hscode, cancellationToken);
        }

        public bool NotContainSpace(string hscode)
        {
            return hscode.NotContainsSpace();
        }
    }
}
