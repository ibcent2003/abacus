using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Command.UpdateRequiredDocument
{
    public class UpdateRequiredDocumentCommandValidator : AbstractValidator<UpdateRequiredDocumentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateRequiredDocumentCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(x => x.DocumentName).NotEmpty().WithName(localizationService.Get("DocumentNamelbl"))
             .MustAsync(BeUniqueDocumentName).WithMessage(localizationService.Get("ErrorBeUniqueDocumentName"));
            RuleFor(x => x.DocumentDescription).NotEmpty().WithName(localizationService.Get("DocumentDescriptionlbl"));
            RuleFor(x => x.DocumentFormatString).NotEmpty().WithName(localizationService.Get("DocumentFormatStringlbl"));
            RuleFor(x => x.MaximumSize).NotEmpty().WithName(localizationService.Get("MaximumSizelbl"));

        }


        public async Task<bool> BeUniqueDocumentName(UpdateRequiredDocumentCommand request, string resourcename, CancellationToken cancellationToken)
        {
            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin))
            {
                return !await _context.RequiredDocuments.AnyAsync(l => l.DocumentName == resourcename && l.Id != request.Id && l.SubscriberId == null, cancellationToken: cancellationToken);
            }

            return !await _context.RequiredDocuments.AnyAsync(l => l.DocumentName == resourcename && l.SubscriberId == request.SubscriberId && l.Id != request.Id, cancellationToken: cancellationToken);
        }
    }
}
