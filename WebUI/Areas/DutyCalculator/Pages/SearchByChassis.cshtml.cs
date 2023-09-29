using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.DutyCalculator.Command;
using Wbc.Application.DutyCalculator.Query;
using Wbc.Domain.Entities;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.DutyCalculator.Pages
{
    public class SearchByChassisModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<SearchByChassisModel> _stringLocalizer;

        public SearchByChassisModel(IMediator mediator, IStringLocalizer<SearchByChassisModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;

        }

        [BindProperty]
        public CreateSearchCommand Command { get; set; }
        [BindProperty]
        public string chassisno { get; set; }


        [BindProperty]
        public CalculatedDuty CalculatedCommand { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var resultData = await _mediator.Send(new CreateSearchCommand { chassis = Command.chassis });
            if (resultData != null)
            {

                CalculatedCommand = await _mediator.Send(new GetCalculatedDutyQuery { TransactionId = resultData.TransactionId });
                if (null == CalculatedCommand)
                {
                    return Page();
                }
                NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
                return RedirectToPage("CalculatedDutyResult", new { TransactionId = resultData.TransactionId });
            }
            return Page();
        }
    }
}
