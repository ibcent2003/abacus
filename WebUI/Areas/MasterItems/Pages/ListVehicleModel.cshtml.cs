using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.MasterItems.Query.GetVehicleModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [Authorize]
    public class ListVehicleModelModel : PageModel
    {
        private readonly IMediator _mediator;
        public ListVehicleModelModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPost()
        {
            var query = new GetVehicleModelListQuery
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
