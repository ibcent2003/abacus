using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.DutyCalculator.Query.GetPendingDuty;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.DutyCalculator.Pages
{
    public class PendingDutyListModel : PageModel
    {

        private readonly IMediator _mediator;
        private readonly IStringLocalizer<PendingDutyListModel> _stringLocalizer;

        public PendingDutyListModel(IMediator mediator, IStringLocalizer<PendingDutyListModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var query = new GetPendingDutyListQuery
            {
                draw = this.GetDataTableDrawValue(),
                start = this.GetDataTableStartValue(),
                length = this.GetDataTableLenghtValue(),
                sortDirection = this.GetDataTableSortColumnDirection(),
                sortColumn = this.GetDataTableSortColumn(),
                search = this.GetDataTableSearchValue()
            };

            var dataTableData = await _mediator.Send(query);

            return new JsonResult(dataTableData);
        }
    }
}
