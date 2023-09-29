using System.Threading.Tasks;
using Application.MasterItems.Command.DeleteHSCodePool;
using Application.MasterItems.Query.GetHSCodePool;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanDeleteHSCode)]
    public class DeleteHSCodePoolModel : PageModel
    {
        private readonly IStringLocalizer<DeleteHSCodePoolModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteHSCodePoolModel(IStringLocalizer<DeleteHSCodePoolModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }

        [BindProperty]
        public DeleteHSCodePoolCommand DeleteHSCodePoolCommand { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            DeleteHSCodePoolCommand = await _mediator.Send(new GetDeleteHSCodePoolCommandQuery { Id = id });

            if (DeleteHSCodePoolCommand == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(DeleteHSCodePoolCommand);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListHSCodePool");
        }
    }
}
