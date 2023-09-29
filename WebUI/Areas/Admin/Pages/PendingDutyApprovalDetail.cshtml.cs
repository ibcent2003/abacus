using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Admin.Command.CreateCalculatedDuty;
using Wbc.Application.Admin.Command.UpdatePendingDuty;
using Wbc.Application.Admin.Query;
using Wbc.Application.Common.Enums;
using Wbc.Application.DutyCalculator.Query;
using Wbc.Domain.Entities;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Admin.Pages
{
    public class PendingDutyApprovalDetailModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<PendingDutyApprovalDetailModel> _stringLocalizer;

        public PendingDutyApprovalDetailModel(IMediator mediator, IStringLocalizer<PendingDutyApprovalDetailModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public UpdatePendingDutyOwnedByCommand Command { get; set; }
        public VehicleSearchPool vehicleInfo { get; set; }
        [BindProperty]
        public AddNewVehicleToFactoryCommand AddCalculatedDuty { get; set; }
        [BindProperty]
        public CalculatedDuty CalCommand { get; set; }
      
        public async Task<IActionResult> OnGet(Guid transactionId)
        {
            
            vehicleInfo = await _mediator.Send(new GetSubmittedVehicleSearch { TransactionId = transactionId });                     
            if(vehicleInfo.HDV==null)
            {
                Command = await _mediator.Send(new GetUpdatePendingDutyOwnedByCommand { TransactionId = transactionId });
                return RedirectToPage("/ManualDutyCalculation", new { TransactionId = vehicleInfo.TransactionId, area = "Admin" });
            }                                                      
            CalCommand = await _mediator.Send(new GetManualCalculatedDutyQuery { TransactionId = transactionId });
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                    
            return Page();
           // Command = await _mediator.Send(new GetUpdatePendingDutyOwnedByCommand { TransactionId = Command.TransactionId });
            var dummy = await _mediator.Send(new AddNewVehicleToFactoryCommand { TransactionId = Command.TransactionId});           
            NotificationHelper.Toast(this, _stringLocalizer["VehicleFactorySuccessTitle"], _stringLocalizer["VehicleFactorySuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
            return RedirectToPage("/NotificationToUser", new { TransactionId = Command.TransactionId, area = "Admin" });
        }
      
        
    }
}
