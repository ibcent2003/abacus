using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Commands.DeleteResourceArea;
using Wbc.Application.MenuResource.Query.GetResourceArea;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanDeleteResourceArea)]
    public class DeleteResourceAreaModel : PageModel
    {
        private readonly IStringLocalizer<DeleteResourceAreaModel> _stringLocalizer;
        private readonly IMediator _mediator;

        public DeleteResourceAreaModel(IStringLocalizer<DeleteResourceAreaModel> stringLocalizer, IMediator mediator)
        {
            _stringLocalizer = stringLocalizer;
            _mediator = mediator;
        }

        [BindProperty]
        public DeleteResourceAreaCommand DeleteResourceAreaCommand { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            DeleteResourceAreaCommand = await _mediator.Send(new GetDeleteResourceAreaCommandQuery { Id = id });

            if (DeleteResourceAreaCommand == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _mediator.Send(DeleteResourceAreaCommand);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListTopResourceArea");
        }
    }
}
