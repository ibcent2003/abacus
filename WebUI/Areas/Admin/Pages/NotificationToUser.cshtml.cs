using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Admin.Command.UpdatePendingDuty;
using Wbc.Application.Admin.Query;
using Wbc.Application.Common.Enums;
using Wbc.Application.DutyCalculator.Query;
using Wbc.Domain.Entities;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Admin.Pages
{
    public class NotificationToUserModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<NotificationToUserModel> _stringLocalizer;

        public NotificationToUserModel(IMediator mediator, IStringLocalizer<NotificationToUserModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public VehicleSearchPool vehicleInfo { get; set; }
        [BindProperty]
        public CalculatedDuty CalCommand { get; set; }
        [BindProperty]
        public UpdateDutyWithMessageCommand WithMessageCommand { get; set; }
        public async Task<IActionResult> OnGet(Guid transactionId)
        {
            vehicleInfo = await _mediator.Send(new GetSubmittedVehicleSearch { TransactionId = transactionId });           
            CalCommand = await _mediator.Send(new GetManualCalculatedDutyQuery { TransactionId = transactionId });
            WithMessageCommand = await _mediator.Send(new GetUpdateDutyWithMessageQuery { TransactionId = transactionId });
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)

                return Page();
           
            var result = await _mediator.Send(WithMessageCommand);
            NotificationHelper.Toast(this, _stringLocalizer["VehicleFactorySuccessTitle"], _stringLocalizer["VehicleFactorySuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
            return RedirectToPage("/AdminDashboard", new { area = "Admin" });
        }

    }
}
