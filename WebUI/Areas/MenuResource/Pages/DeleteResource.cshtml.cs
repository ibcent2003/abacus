using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Commands.DeleteResource;
using Wbc.Application.MenuResource.Query.GetResource;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanDeleteResource)]
    public class DeleteResourceModel : PageModel
    {
        private readonly IStringLocalizer<DeleteResourceModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteResourceModel(IStringLocalizer<DeleteResourceModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }

        [BindProperty]
        public DeleteResourceCommand DeleteResourceCommand { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            DeleteResourceCommand = await _mediator.Send(new GetDeleteResourceCommandQuery { Id = id });

            if (DeleteResourceCommand == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(DeleteResourceCommand);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListResource");
        }
    }
}
