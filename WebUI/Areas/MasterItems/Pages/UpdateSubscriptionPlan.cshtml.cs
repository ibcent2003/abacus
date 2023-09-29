using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.MasterItems.Query.GetSubscriptionPlan;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.UpdateSubscriptionPlan;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{

    [Authorize]
    public class UpdateSubscriptionPlanModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateSubscriptionPlanModel> _stringLocalizer;
        public UpdateSubscriptionPlanModel(IMediator mediator, IStringLocalizer<UpdateSubscriptionPlanModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        public int Id { get; set; }

        [BindProperty]
        public UpdateSubscriptionPlanCommand Command { get; set; }
        public SelectList SubcriptionTypeList { get; set; }
        public SelectList CountryList { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            var subplanVm = await _mediator.Send(new GetUpdateSubscriptionPlanComandQuery { Id = id });
            Command = subplanVm.UpdateCommand;
            if (Command == null) return NotFound();
            SubcriptionTypeList = new SelectList(subplanVm.SubscriptionTypesHeader, "Id", "Name");
            CountryList = new SelectList(subplanVm.Countries, "Id", "CountryName");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {

                var subplanVm = await _mediator.Send(new GetUpdateSubscriptionPlanComandQuery { Id = Command.Id });

                SubcriptionTypeList = new SelectList(subplanVm.SubscriptionTypesHeader, "Id", "Name");
                CountryList = new SelectList(subplanVm.Countries, "Id", "Name");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListSubscriptionPlan");
        }
    }
}
