using System.Threading.Tasks;
using Application.MasterItems.Command.UpdateDocumentCategory;
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
    [AuthorizePolicy(Policies.CanUpdateDocumentCategory)]
    public class UpdateDocumentCategoryModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateDocumentCategoryModel> _stringLocalizer;
        public UpdateDocumentCategoryModel(IMediator mediator, IStringLocalizer<UpdateDocumentCategoryModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public UpdateDocumentCategoryCommand Command { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetUpdateDocumentCategoryCommandQuery { Id = id });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListDocumentCategory");
        }
    }
}
