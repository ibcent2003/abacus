using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MenuResource.Query.GetTopResource;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace Wbc.WebUI.Areas.MenuResource.Pages
{
    [AuthorizePolicy(Policies.CanListTopResource)]
    public class ListTopResourceModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<ListTopResourceModel> _stringLocalizer;

        public ListTopResourceModel(IMediator mediator, IStringLocalizer<ListTopResourceModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPost()
        {
            var query = new GetTopResourceListQuery
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
