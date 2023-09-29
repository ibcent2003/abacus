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
    public class CalculatedDutyResultModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<CalculatedDutyResultModel> _stringLocalizer;

        public CalculatedDutyResultModel(IMediator mediator, IStringLocalizer<CalculatedDutyResultModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public CalculatedDuty Command { get; set; }
        public async Task<IActionResult> OnGet(Guid transactionId)
        {
            Command = await _mediator.Send(new GetCalculatedDutyQuery { TransactionId = transactionId });

            return Page();
        }
    }
}
