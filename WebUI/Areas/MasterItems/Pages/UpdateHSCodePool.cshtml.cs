using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.MasterItems.Command.UpdateHSCodePool;
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
    [AuthorizePolicy(Policies.CanUpdateHSCode)]
    public class UpdateHSCodePoolModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<UpdateHSCodePoolModel> _stringLocalizer;
        public UpdateHSCodePoolModel(IMediator mediator, IStringLocalizer<UpdateHSCodePoolModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public UpdateHSCodePoolCommand Command { get; set; }
        public int Id { get; set; }
        public SelectList CountryList { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var hscodePoolVm = await _mediator.Send(new GetUpdateHSCodePoolCommandQuery { Id = id});
            Command = hscodePoolVm.UpdateHSCodePoolCommand;
            if (Command == null) return NotFound();

            CountryList = new SelectList(hscodePoolVm.Countries, "Id", "CountryName");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var hscodePoolVm = await _mediator.Send(new GetUpdateHSCodePoolCommandQuery { Id = Command.Id });

                CountryList = new SelectList(hscodePoolVm.Countries, "Id", "CountryName");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListHSCodePool");
        }

    }
}
