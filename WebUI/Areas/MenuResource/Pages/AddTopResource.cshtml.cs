using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Commands.CreateTopResource;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanAddTopResource)]
    public class AddTopResourceModel : PageModel
    {
        private readonly IStringLocalizer<AddTopResourceModel> _stringLocalizer;
        private readonly IMediator _mediator;
        [BindProperty]
        public CreateTopResourceCommand CommandRequest { get; set; }
        public AddTopResourceModel(IStringLocalizer<AddTopResourceModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dummy = await _mediator.Send(CommandRequest);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListTopResource");
        }
    }
}
