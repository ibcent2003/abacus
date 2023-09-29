using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Commands.CreateResourceArea;
using Wbc.Application.MenuResource.Query.GetResourceArea;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanAddResourceArea)]
    public class AddResourceAreaModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddResourceAreaModel> _stringLocalizer;

        public AddResourceAreaModel(IMediator mediator, IStringLocalizer<AddResourceAreaModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public CreateResourceAreaCommand Command { get; set; }

        public SelectList ResourceHeaderList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var resourceAreaVm = await _mediator.Send(new GetAddResourceAreaCommandQuery());

            ResourceHeaderList = new SelectList(resourceAreaVm.ResourceHeaders, "Id", "ResourceName");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var resourceAreaVm = await _mediator.Send(new GetAddResourceAreaCommandQuery());

                ResourceHeaderList = new SelectList(resourceAreaVm.ResourceHeaders, "Id", "ResourceName");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListResourceArea");
        }
    }
}
