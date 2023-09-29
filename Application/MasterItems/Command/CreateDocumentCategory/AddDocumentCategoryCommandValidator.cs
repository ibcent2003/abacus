using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Application.MasterItems.Command.CreateDocumentCategory
{
    class AddDocumentCategoryCommandValidator : AbstractValidator<AddDocumentCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddDocumentCategoryCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;

            RuleFor(x => x.CategoryName).NotEmpty().WithName(localizationService.Get("DocumentCategoryNamelbl"))
             .MustAsync(BeUniqueCategoryName).WithMessage(localizationService.Get("ErrorBeUniqueDocumentCategoryName"));

        }

        public async Task<bool> BeUniqueCategoryName(string resourcename, CancellationToken cancellationToken)
        {
            return !await _context.DocumentCategories.AnyAsync(l => l.CategoryName == resourcename, cancellationToken: cancellationToken);
        }
    }
}
