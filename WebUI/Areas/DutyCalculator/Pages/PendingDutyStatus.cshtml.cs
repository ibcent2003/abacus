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

namespace Wbc.WebUI.Areas.DutyCalculator.Pages
{
    public class PendingDutyStatusModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<PendingDutyStatusModel> _stringLocalizer;


        public PendingDutyStatusModel(IMediator mediator, IStringLocalizer<PendingDutyStatusModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;

        }
        [BindProperty]
        public VehicleSearchPool Command { get; set; }


        public decimal HDV { get; set; }
        public async Task<IActionResult> OnGet(Guid transactionId)
        {
            Command = await _mediator.Send(new GetSubmittedVehicleSearch { TransactionId = transactionId });
            return Page();
        }
    }
}
