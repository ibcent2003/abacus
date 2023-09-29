using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Query.GetResource;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanListResource)]
    public class ListResourceModel : PageModel
    {
        private readonly IMediator _mediator;

        public ListResourceModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var query = new GetResourceListQuery()
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
