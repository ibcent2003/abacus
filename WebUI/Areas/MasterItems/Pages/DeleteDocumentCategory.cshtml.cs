using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.MasterItems.Command.DeleteDocumentCategory;
using Application.MasterItems.Query.GetDocumentCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanDeleteDocumentCategory)]
    public class DeleteDocumentCategoryModel : PageModel
    {
        private readonly IStringLocalizer<DeleteDocumentCategoryModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteDocumentCategoryModel(IStringLocalizer<DeleteDocumentCategoryModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }


        [BindProperty]
        public DeleteDocumentCategoryCommand Command { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetDeleteDocumentCategoryCommandQuery { Id = id });

            if (Command == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListDocumentCategory");
        }
    }
}
