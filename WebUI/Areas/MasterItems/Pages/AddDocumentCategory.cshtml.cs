using System.Threading.Tasks;
using Application.MasterItems.Command.CreateDocumentCategory;
using Application.MasterItems.Query.GetDocumentCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanAddDocumentCategory)]
    public class AddDocumentCategoryModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddDocumentCategoryModel> _stringLocalizer;

        public AddDocumentCategoryModel(IMediator mediator, IStringLocalizer<AddDocumentCategoryModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public AddDocumentCategoryCommand Command { get; set; }

        public SelectList DocumentTypeList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var documentCategoryVm = await _mediator.Send(new GetAddDocumentCategoryCommandQuery());

            DocumentTypeList = new SelectList(documentCategoryVm.DocumentTypes, "Id", "DocumentTypeName");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var documentCategoryVm = await _mediator.Send(new GetAddDocumentCategoryCommandQuery());

                DocumentTypeList = new SelectList(documentCategoryVm.DocumentTypes, "Id", "DocumentTypeName");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListDocumentCategory");
        }
    }
}
