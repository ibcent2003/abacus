using System.Threading.Tasks;
using Application.MasterItems.Command.CreateVehicleModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Query.GetVehicleModel;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [Authorize]
    public class AddVehicleModelModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddVehicleModelModel> _stringLocalizer;


        public AddVehicleModelModel(IMediator mediator, IStringLocalizer<AddVehicleModelModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public AddVehicleModelCommand Command { get; set; }
        public SelectList MakeList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var subplanVm = await _mediator.Send(new GetAddVehicleModelCommandQuery());
            MakeList = new SelectList(subplanVm.VehicleMakeList, "Id", "MakeName");        
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var subplanVm = await _mediator.Send(new GetAddVehicleModelCommandQuery());
                MakeList = new SelectList(subplanVm.VehicleMakeList, "Id", "MakeName");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListVehicleModel");
        }

    }
}
