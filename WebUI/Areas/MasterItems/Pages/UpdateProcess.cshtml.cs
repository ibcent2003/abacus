using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.UpdateProcess;
using Wbc.Application.MasterItems.Query.GetProcess;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanUpdateProcess)]
    public class UpdateProcessModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateProcessModel> _stringLocalizer;
        public UpdateProcessModel(IMediator mediator, IStringLocalizer<UpdateProcessModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public UpdateProcessCommand Command { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetUpdateProcessCommandQuery { Id = id });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListProcess");
        }
    }
}
