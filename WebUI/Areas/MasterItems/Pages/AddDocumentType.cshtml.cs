using System.Threading.Tasks;
using Application.MasterItems.Command.CreateDocumentType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanAddDocumentType)]
    public class AddDocumentTypeModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddDocumentTypeModel> _stringLocalizer;

        public AddDocumentTypeModel(IMediator mediator, IStringLocalizer<AddDocumentTypeModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public AddDocumentTypeCommand Command { get; set; }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListDocumentType");
        }
    }
}
