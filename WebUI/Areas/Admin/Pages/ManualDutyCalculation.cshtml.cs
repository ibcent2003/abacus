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
    public class ManualDutyCalculationModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<ManualDutyCalculationModel> _stringLocalizer;

        public ManualDutyCalculationModel(IMediator mediator, IStringLocalizer<ManualDutyCalculationModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]      
        public VehicleSearchPool vehicleInfo { get; set; }

        [BindProperty]
        public UpdatePendingDutyToCalculatedCommand updateDuty { get; set; }

        public async Task<IActionResult> OnGet(Guid transactionId)
        {           
            vehicleInfo = await _mediator.Send(new GetSubmittedVehicleSearch { TransactionId = transactionId });
            updateDuty = await _mediator.Send(new GetUpdateManualCalculation { TransactionId = transactionId });
            
           
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Toast(this, _stringLocalizer["ErrorTitle"], _stringLocalizer["ErrorMessage"], NotificationType.Error, NotificationPosition.TopRight);
                return Page();
            }           
            var result = await _mediator.Send(updateDuty);             
            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
           return RedirectToPage("/PendingDutyApprovalDetail", new { TransactionId= updateDuty.TransactionId, area = "Admin" });
        }
    }
}
