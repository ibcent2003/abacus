using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Admin.Query;
using Wbc.Application.Admin.Query.GetDashboardItemsCount;
using Wbc.Domain.Entities;

namespace Wbc.WebUI.Areas.Admin.Pages
{
    public class AdminDashboardModel : PageModel
    {

        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AdminDashboardModel> _stringLocalizer;


        public AdminDashboardModel(IMediator mediator, IStringLocalizer<AdminDashboardModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;

        }
        [BindProperty]
        public List<VehicleSearchPool> CountSubmittedDuty { get; set; }
        public List<VehicleSearchPool> CountOwnedByDuty { get; set; }
        public List<CalculatedDuty> CountAllCalculatedDuty { get; set; }

        public async Task<IActionResult> OnGet()
        {
            CountSubmittedDuty = await _mediator.Send(new GetSubmittedDutyCountQuery());
            CountOwnedByDuty = await _mediator.Send(new CountOwnedByDutyQuery());
            CountAllCalculatedDuty = await _mediator.Send(new CountAllCalculatedDutyQuery());
            return Page();
        }
    }
}
