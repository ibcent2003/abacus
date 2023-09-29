using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Command.CreateProcess
{
    public class AddProcessCommandValidator : AbstractValidator<AddProcessCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddProcessCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;

            RuleFor(x => x.ProcessName).NotEmpty().WithName(localizationService.Get("ProcessNamelbl"))
             .MustAsync(BeUniqueProcessName).WithMessage(localizationService.Get("ErrorBeUniqueProcessName"));

            RuleFor(x => x.ProcessDescription).NotEmpty().WithName(localizationService.Get("ProcessDescriptionlbl"));

            RuleFor(x => x.ProcessCode).NotEmpty().WithName(localizationService.Get("ProcessCodelbl"))
            .MustAsync(BeUniqueProcessCode).WithMessage(localizationService.Get("ErrorBeUniqueProcessCode"));

        }

        public async Task<bool> BeUniqueProcessName(string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.Processes.AnyAsync(l => l.ProcessName == resourcename, cancellationToken: cancellationToken);
        }

        public async Task<bool> BeUniqueProcessCode(string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.Processes.AnyAsync(l => l.ProcessCode == resourcename, cancellationToken: cancellationToken);
        }
    }
}
