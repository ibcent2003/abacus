using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.UpdateRequiredDocument;
using Wbc.Application.MasterItems.Query.GetRequiredDocument;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanUpdateRequiredDocument)]
    public class UpdateRequiredDocumentModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateRequiredDocumentModel> _stringLocalizer;
        public UpdateRequiredDocumentModel(IMediator mediator, IStringLocalizer<UpdateRequiredDocumentModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public UpdateRequiredDocumentCommand Command { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetUpdateRequiredDocumentCommandQuery { Id = id });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListRequiredDocument");
        }

    }
}
