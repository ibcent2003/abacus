using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.MasterItems.Command.CreateHSCodePool;
using Application.MasterItems.Query.GetHSCodePool;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanAddHSCode)]
    public class AddHSCodePoolModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddHSCodePoolModel> _stringLocalizer;

        public AddHSCodePoolModel(IMediator mediator, IStringLocalizer<AddHSCodePoolModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public AddHscodePoolCommand Command { get; set; }

        public SelectList CountryList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var hscodePoolVm = await _mediator.Send(new GetAddHSCodePoolCommandQuery());

            CountryList = new SelectList(hscodePoolVm.Countries, "Id", "CountryName");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var hscodePoolVm = await _mediator.Send(new GetAddHSCodePoolCommandQuery());

                CountryList = new SelectList(hscodePoolVm.Countries, "Id", "CountryName");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListHSCodePool");
        }

    }
}
