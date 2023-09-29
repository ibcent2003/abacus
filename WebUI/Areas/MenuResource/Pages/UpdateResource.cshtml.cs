using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Commands.UpdateResource;
using Wbc.Application.MenuResource.Query.GetResource;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanUpdateResource)]
    public class UpdateResourceModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateResourceModel> _stringLocalizer;
        public UpdateResourceModel(IMediator mediator, IStringLocalizer<UpdateResourceModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public UpdateResourceCommand Command { get; set; }
        public int Id { get; set; }
        public SelectList ResourceAreaList { get; set; }
        public SelectList PermissionList { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {

            var resourceVm = await _mediator.Send(new GetUpdateResourceCommandQuery { Id = id });

            Command = resourceVm.UpdateCommand;

            if (Command == null) return NotFound();

            ResourceAreaList = new SelectList(resourceVm.ResourceAreas, "Id", "AreaName");
            PermissionList = new SelectList(resourceVm.Permissions, "Id", "PersmissionDescription");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var resourceVm = await _mediator.Send(new GetUpdateResourceCommandQuery { Id = Command.Id });

                ResourceAreaList = new SelectList(resourceVm.ResourceAreas, "Id", "AreaName");

                PermissionList = new SelectList(resourceVm.Permissions, "Id", "PersmissionDescription");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListResource");
        }
    }
}
