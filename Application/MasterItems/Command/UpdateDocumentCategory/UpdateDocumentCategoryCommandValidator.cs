using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Application.MasterItems.Command.UpdateDocumentCategory
{
    public class UpdateDocumentCategoryCommandValidator : AbstractValidator<UpdateDocumentCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateDocumentCategoryCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;

            RuleFor(x => x.CategoryName).NotEmpty().WithName(localizationService.Get("CategoryNamelbl"));

        }
    }
}
