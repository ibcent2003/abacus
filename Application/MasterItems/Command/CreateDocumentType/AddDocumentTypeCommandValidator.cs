using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Application.MasterItems.Command.CreateDocumentType
{
    public class AddDocumentTypeCommandValidator : AbstractValidator<AddDocumentTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddDocumentTypeCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;

            RuleFor(x => x.DocumentTypeName).NotEmpty().WithName(localizationService.Get("DocumentTypeNamelbl"))
             .MustAsync(BeUniqueDocumentTypeName).WithMessage(localizationService.Get("ErrorBeUniqueDocumentTypeName"));

            RuleFor(x => x.DocumentTypeCode).NotEmpty().WithName(localizationService.Get("DocumentTypeCodelbl"))
          .MustAsync(BeUniqueDocumentTypeCode).WithMessage(localizationService.Get("ErrorBeUniqueDocumentTypeCode"));
        }



        public async Task<bool> BeUniqueDocumentTypeName(string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.DocumentTypes.AnyAsync(l => l.DocumentTypeName == resourcename, cancellationToken: cancellationToken);
        }


        public async Task<bool> BeUniqueDocumentTypeCode(string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.DocumentTypes.AnyAsync(l => l.DocumentTypeCode == resourcename, cancellationToken: cancellationToken);
        }


    }
}
