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

namespace Application.MasterItems.Command.UpdateDocumentType
{
    public class UpdateDocumentTypeCommandValidator : AbstractValidator<UpdateDocumentTypeCommand>
    {

        private readonly IApplicationDbContext _context;
        public UpdateDocumentTypeCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {

            _context = context;

            RuleFor(x => x.DocumentTypeName).NotEmpty().WithName(localizationService.Get("DocumentTypeNamelbl"))
             .MustAsync(BeUniqueDocumentTypeName).WithMessage(localizationService.Get("ErrorBeUniqueDocumentTypeName"));

            RuleFor(x => x.DocumentTypeCode).NotEmpty().WithName(localizationService.Get("DocumentTypeCodelbl"))
          .MustAsync(BeUniqueDocumentTypeCode).WithMessage(localizationService.Get("ErrorBeUniqueDocumentTypeCode"));
        }

        public async Task<bool> BeUniqueDocumentTypeName(UpdateDocumentTypeCommand request, string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.DocumentTypes.Where(x => x.Id != request.Id).AnyAsync(l => l.DocumentTypeName == resourcename, cancellationToken: cancellationToken);
        }


        public async Task<bool> BeUniqueDocumentTypeCode(UpdateDocumentTypeCommand request, string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.DocumentTypes.Where(x => x.Id != request.Id).AnyAsync(l => l.DocumentTypeCode == resourcename, cancellationToken: cancellationToken);
        }
    }
}
