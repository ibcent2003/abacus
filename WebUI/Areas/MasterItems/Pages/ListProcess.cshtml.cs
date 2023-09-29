using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Query.GetProcess;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{

    [AuthorizePolicy(Policies.CanListProcess)]
    public class ListProcessModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<ListProcessModel> _stringLocalizer;
        public ListProcessModel(IMediator mediator, IStringLocalizer<ListProcessModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var query = new GetProcessListQuery
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
