using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.UpdateSubscriptionType;
using Wbc.Application.MasterItems.Query.GetSubscriptionType;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [Authorize]
    public class UpdateSubscriptionTypeModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateSubscriptionTypeModel> _stringLocalizer;

        public UpdateSubscriptionTypeModel(IMediator mediator, IStringLocalizer<UpdateSubscriptionTypeModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public UpdateSubscriptionTypeCommand Command { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Command = await _mediator.Send(new GetUpdateSubscriptionTypeCommandQuery { Id = id });

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListSubscriptionType");
        }
    }
}
