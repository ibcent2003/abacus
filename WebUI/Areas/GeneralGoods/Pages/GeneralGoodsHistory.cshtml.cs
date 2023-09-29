using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.GeneralGoods.Query;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.GeneralGoods.Pages
{
    public class GeneralGoodsHistoryModel : PageModel
    {
        private readonly IMediator _mediator;

        public GeneralGoodsHistoryModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {

            var query = new GetGeneralGoodsHistoryListQuery
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
