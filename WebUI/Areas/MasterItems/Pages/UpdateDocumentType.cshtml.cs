using System.Threading.Tasks;
using Application.MasterItems.Command.UpdateDocumentType;
using Application.MasterItems.Query.GetDocumentType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanUpdateDocumentType)]
    public class UpdateDocumentTypeModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateDocumentTypeModel> _stringLocalizer;
        public UpdateDocumentTypeModel(IMediator mediator, IStringLocalizer<UpdateDocumentTypeModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public UpdateDocumentTypeCommand Command { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetUpdateDocumentTypeCommandQuery { Id = id });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListDocumentType");
        }
    }
}
