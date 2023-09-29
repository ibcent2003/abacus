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
    public class OwnedByDutyApprovalListModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<OwnedByDutyApprovalListModel> _stringLocalizer;

        public OwnedByDutyApprovalListModel(IMediator mediator, IStringLocalizer<OwnedByDutyApprovalListModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var query = new GetOwnedByApprovalDutyListQuery
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
