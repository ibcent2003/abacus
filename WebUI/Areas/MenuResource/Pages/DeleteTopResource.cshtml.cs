using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Commands.DeleteTopResource;
using Wbc.Application.MenuResource.Query.GetTopResource;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanDeleteTopResource)]
    public class DeleteTopResourceModel : PageModel
    {
        private readonly IStringLocalizer<DeleteTopResourceModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteTopResourceModel(IStringLocalizer<DeleteTopResourceModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }

        [BindProperty]
        public DeleteTopResourceCommand DeleteCommand { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {

            DeleteCommand = await _mediator.Send(new GetDeleteTopResourceCommandQuery { Id = id });

            if (DeleteCommand == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(DeleteCommand);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListTopResource");
        }
    }
}
