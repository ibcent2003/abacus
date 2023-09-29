using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Command.CreateProcessRequiredDocument
{
    public class AddProcessRequiredDocumentCommandValidator : AbstractValidator<AddProcessRequiredDocumentCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddProcessRequiredDocumentCommandValidator(IApplicationDbContext context, CommonLocalizationService commonLocalizationService)
        {
            _context = context;

            RuleFor(x => x.RequiredDocumentId).NotEmpty().WithName(commonLocalizationService.Get("RequiredDocumentIdlbl")).MustAsync(BeUniqueRequiredDocument).WithMessage(commonLocalizationService.Get("ErrorBeUniqueProcessCode"));

        }

        public async Task<bool> BeUniqueRequiredDocument(AddProcessRequiredDocumentCommand request, int resourcename, CancellationToken cancellationToken)
        {
            if (request.IsInternalUse)
            {
                return !await _context.ProcessRequiredDocuments.AnyAsync(x => x.ProcessId == request.ProcessId &&
                                                                    x.RequiredDocumentId == request.RequiredDocumentId && x.SubscriberId == null,
                                                                             cancellationToken: cancellationToken);

            }

            return !await _context.ProcessRequiredDocuments.AnyAsync(x => x.ProcessId == request.ProcessId &&
                                                                          x.RequiredDocumentId == request.RequiredDocumentId &&
                                                                          x.SubscriberId.Value == request.SubscriberId, cancellationToken);
        }

    }
}
