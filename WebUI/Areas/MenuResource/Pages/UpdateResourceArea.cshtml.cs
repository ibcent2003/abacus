using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Commands.UpdateResourceArea;
using Wbc.Application.MenuResource.Query.GetResourceArea;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanUpdateResourceArea)]
    public class UpdateResourceAreaModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateResourceAreaModel> _stringLocalizer;
        public UpdateResourceAreaModel(IMediator mediator, IStringLocalizer<UpdateResourceAreaModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public UpdateResourceAreaCommand Command { get; set; }
        public int Id { get; set; }
        public SelectList ResourceHeaderList { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {

            var resourceAreaVm = await _mediator.Send(new GetUpdateResourceAreaCommandQuery { Id = id });

            Command = resourceAreaVm.UpdateCommand;

            if (Command == null) return NotFound();

            ResourceHeaderList = new SelectList(resourceAreaVm.ResourceHeaders, "Id", "ResourceName");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {

                var resourceAreaVm = await _mediator.Send(new GetUpdateResourceAreaCommandQuery { Id = Command.Id });

                ResourceHeaderList = new SelectList(resourceAreaVm.ResourceHeaders, "Id", "ResourceName");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListResourceArea");
        }
    }
}
