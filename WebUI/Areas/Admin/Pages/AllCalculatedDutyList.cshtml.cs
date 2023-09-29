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
    public class AllCalculatedDutyListModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AllCalculatedDutyListModel> _stringLocalizer;

        public AllCalculatedDutyListModel(IMediator mediator, IStringLocalizer<AllCalculatedDutyListModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var query = new GetAllCalculateDutyListQuery
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
