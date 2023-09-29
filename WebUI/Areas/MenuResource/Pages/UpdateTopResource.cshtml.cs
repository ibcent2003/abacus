using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Commands.UpdateTopResource;
using Wbc.Application.MenuResource.Query.GetTopResource;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanUpdateTopResource)]
    public class UpdateTopResourceModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateTopResourceModel> _stringLocalizer;

        public UpdateTopResourceModel(IMediator mediator, IStringLocalizer<UpdateTopResourceModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }


        public int Id { get; set; }
        [BindProperty]
        public UpdateTopResourceCommand UpdateCommand { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {

            UpdateCommand = await _mediator.Send(new GetUpdateTopResourceCommandQuery { Id = id });

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(UpdateCommand);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListTopResource");
        }
    }
}
