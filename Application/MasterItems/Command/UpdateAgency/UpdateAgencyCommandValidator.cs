using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Application.MasterItems.Command.UpdateAgency
{
    public class UpdateAgencyCommandValidator : AbstractValidator<UpdateAgencyCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAgencyCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;

            RuleFor(x => x.AgencyVm.AgencyDto.AgencyName).NotEmpty().WithName(localizationService.Get("AgencyNamelbl"))
             .MustAsync(BeUniqueAgencyName).WithMessage(localizationService.Get("ErrorBeUniqueAgencyName"));

            RuleFor(x => x.AgencyVm.AgencyDto.AgencyCode).NotEmpty().WithName(localizationService.Get("AgencyCodelbl"))
          .MustAsync(BeUniqueAgencyCode).WithMessage(localizationService.Get("ErrorBeUniqueAgencyCode"));
        }

        public async Task<bool> BeUniqueAgencyName(UpdateAgencyCommand request, string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.Agencies.Where(x => x.Id != request.AgencyVm.AgencyDto.Id).AnyAsync(l => l.AgencyName == resourcename, cancellationToken: cancellationToken);
        }
        public async Task<bool> BeUniqueAgencyCode(UpdateAgencyCommand request, string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.Agencies.Where(x => x.Id != request.AgencyVm.AgencyDto.Id).AnyAsync(l => l.AgencyCode == resourcename, cancellationToken: cancellationToken);
        }
    }
}
