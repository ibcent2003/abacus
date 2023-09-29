using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.DutyCalculator.Query;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.DutyCalculator.Pages
{
    public class DutySearchHistoryModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<DutySearchHistoryModel> _stringLocalizer;

        public DutySearchHistoryModel(IMediator mediator, IStringLocalizer<DutySearchHistoryModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var query = new GetSearchHistoryListQuery
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
