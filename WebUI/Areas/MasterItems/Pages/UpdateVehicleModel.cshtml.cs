using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.UpdateVehicleModel;
using Wbc.Application.MasterItems.Query.GetVehicleModel;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [Authorize]
    public class UpdateVehicleModelModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateVehicleModelModel> _stringLocalizer;

        public UpdateVehicleModelModel(IMediator mediator, IStringLocalizer<UpdateVehicleModelModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        public int Id { get; set; }

        [BindProperty]
        public UpdateVehicleModelCommand Command { get; set; }
        public SelectList MakeList { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            var subplanVm = await _mediator.Send(new GetUpdateVehicleModelCommandQuery { Id = id });
            Command = subplanVm.UpdateCommand;
            if (Command == null) 
              return NotFound();
            MakeList = new SelectList(subplanVm.VehicleMakeList, "Id", "MakeName");
           
            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {

                var subplanVm = await _mediator.Send(new GetUpdateVehicleModelCommandQuery { Id = Command.Id });
                MakeList = new SelectList(subplanVm.VehicleMakeList, "Id", "MakeName");               
                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListVehicleModel");
        }
    }
}
