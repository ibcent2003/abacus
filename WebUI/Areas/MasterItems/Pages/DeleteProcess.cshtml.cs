using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.DeleteProcess;
using Wbc.Application.MasterItems.Query.GetProcess;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanDeleteProcess)]
    public class DeleteProcessModel : PageModel
    {
        private readonly IStringLocalizer<DeleteProcessModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteProcessModel(IStringLocalizer<DeleteProcessModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }


        [BindProperty]
        public DeleteProcessCommand Command { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetDeleteProcessCommandQuery { Id = id });

            if (Command == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListProcess");
        }
    }
}
