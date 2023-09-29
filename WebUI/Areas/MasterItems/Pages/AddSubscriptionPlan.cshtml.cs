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
using Wbc.Application.MasterItems.CreateSubscriptionPlan;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [Authorize]
    public class AddSubscriptionPlanModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddSubscriptionPlanModel> _stringLocalizer;


        public AddSubscriptionPlanModel(IMediator mediator, IStringLocalizer<AddSubscriptionPlanModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public CreateSubscriptionPlanCommand Command { get; set; }
        public SelectList SubcriptionTypeList { get; set; }
        public SelectList CountryList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var subplanVm = await _mediator.Send(new GetAddSubscriptionPlanCommandQuery());

            SubcriptionTypeList = new SelectList(subplanVm.SubscriptionTypesHeader, "Id", "Name");
            CountryList = new SelectList(subplanVm.Countries, "Id", "CountryName");

            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var subplanVm = await _mediator.Send(new GetAddSubscriptionPlanCommandQuery());

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
