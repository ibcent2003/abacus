using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Admin.Query;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Admin.Pages
{
    public class PendingDutyApprovalListModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<PendingDutyApprovalListModel> _stringLocalizer;

        public PendingDutyApprovalListModel(IMediator mediator, IStringLocalizer<PendingDutyApprovalListModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var query = new GetPendingApprovalDutyListQuery
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
