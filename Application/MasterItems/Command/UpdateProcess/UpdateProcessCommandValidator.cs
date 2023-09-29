using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Command.UpdateProcess
{
    public class UpdateProcessCommandValidator : AbstractValidator<UpdateProcessCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProcessCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;

            RuleFor(x => x.ProcessName).NotEmpty().WithName(localizationService.Get("ProcessNamelbl"))
             .MustAsync(BeUniqueProcessName).WithMessage(localizationService.Get("ErrorBeUniqueProcessName"));

            RuleFor(x => x.ProcessDescription).NotEmpty().WithName(localizationService.Get("ProcessDescriptionlbl"));

            RuleFor(x => x.ProcessCode).NotEmpty().WithName(localizationService.Get("ProcessCodelbl"))
            .MustAsync(BeUniqueProcessCode).WithMessage(localizationService.Get("ErrorBeUniqueProcessCode"));


        }

        public async Task<bool> BeUniqueProcessName(UpdateProcessCommand request, string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.Processes.AnyAsync(l => l.ProcessName == resourcename && l.Id != request.Id, cancellationToken: cancellationToken);
        }

        public async Task<bool> BeUniqueProcessCode(UpdateProcessCommand request, string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.Processes.AnyAsync(l => l.ProcessCode == resourcename && l.Id != request.Id, cancellationToken: cancellationToken);
        }
    }
}
