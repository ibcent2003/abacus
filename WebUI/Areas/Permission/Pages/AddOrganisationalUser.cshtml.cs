using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Commands.CreateOrganisationalUser;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;


namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanAddOrganisationalUser)]
    public class AddOrganisationalUserModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddOrganisationalUserModel> _stringLocalizer;

        public AddOrganisationalUserModel(IMediator mediator, IStringLocalizer<AddOrganisationalUserModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public CreateOrganisationalUserCommand Command { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("OrganisationalUsers");
        }
    }
}
