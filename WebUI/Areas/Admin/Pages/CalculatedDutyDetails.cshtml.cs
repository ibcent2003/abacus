using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.DutyCalculator.Query;
using Wbc.Domain.Entities;

namespace Wbc.WebUI.Areas.Admin.Pages
{
    public class CalculatedDutyDetailsModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<CalculatedDutyDetailsModel> _stringLocalizer;

        public CalculatedDutyDetailsModel(IMediator mediator, IStringLocalizer<CalculatedDutyDetailsModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
        public VehicleSearchPool vehicleInfo { get; set; }
        public CalculatedDuty Command { get; set; }
        public async Task<IActionResult> OnGet(Guid transactionId)
        {

            vehicleInfo = await _mediator.Send(new GetSubmittedVehicleSearch { TransactionId = transactionId });
            Command = await _mediator.Send(new GetCalculatedDutyQuery { TransactionId = transactionId });            
            return Page();
        }
    }
}
